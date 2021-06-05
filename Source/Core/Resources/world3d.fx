// 3D world rendering shader
// Copyright (c) 2007 Pascal vd Heiden, www.codeimp.com

// Vertex input data
struct VertexData
{
	float3 pos		  : POSITION;
	float4 color	  : COLOR0;
	float2 uv		    : TEXCOORD0;
	float3 normal   : NORMAL; //mxd
};

// Pixel input data
struct PixelData
{
	float4 pos		: POSITION;
	float4 color	: COLOR0;
	float2 uv		  : TEXCOORD0;
};

//mxd. Vertex input data for sky rendering
struct SkyVertexData
{
	float3 pos		: POSITION;
	float2 uv			: TEXCOORD0;
};

//mxd. Pixel input data for sky rendering
struct SkyPixelData
{
	float4 pos		: POSITION;
	float3 tex		: TEXCOORD0;
};

//mxd. Pixel input data for light pass
struct LitPixelData
{
	float4 pos		  : POSITION;
	float4 color	  : COLOR0;
	float2 uv		    : TEXCOORD0;
	float4 pos_w    : TEXCOORD1; //mxd. pixel position in world space (DC: added a 'w' component to encode pixel depth)
	float3 normal   : TEXCOORD2; //mxd. normal
};

// Highlight color
float4 highlightcolor;

// Matrix for final transformation
const float4x4 worldviewproj;

//mxd
float4x4 world;
float4 vertexColor;
// [ZZ]
float4 stencilColor;

//[GEC]
float LightLevel;
int LightMode;

//light
float4 lightPosAndRadius;
float3 lightOrientation; // this is a vector that points in light's direction
float2 light2Radius; // this is used with spotlights
float4 lightColor; //also used as fog color
float ignoreNormals; // ignore normals in lighting equation. used for non-attenuated lights on models.
float spotLight; // use lightOrientation

//fog
const float4 campos;  //w is set to fade factor (distance, at wich fog color completely overrides pixel color)

//sky
static const float4 skynormal = float4(0.0f, 1.0f, 0.0f, 0.0f);

// Texture input
const texture texture1;

// Filter settings
const dword minfiltersettings;
const dword magfiltersettings;
const dword mipfiltersettings;
const float maxanisotropysetting;

// Texture sampler settings
sampler2D texturesamp = sampler_state
{
	Texture = <texture1>;
	MagFilter = magfiltersettings;
	MinFilter = minfiltersettings;
	MipFilter = mipfiltersettings;
	MipMapLodBias = 0.0f;
	MaxAnisotropy = maxanisotropysetting;
};

//mxd. Skybox texture sampler settings
samplerCUBE skysamp = sampler_state
{
	Texture = <texture1>;
	MagFilter = magfiltersettings;
	MinFilter = minfiltersettings;
	MipFilter = mipfiltersettings;
	MipMapLodBias = 0.0f;
	MaxAnisotropy = maxanisotropysetting;
};

// Vertex shader
PixelData vs_main(VertexData vd) 
{
	PixelData pd;
	
	// Fill pixel data input
	pd.pos = mul(float4(vd.pos, 1.0f), worldviewproj);
	pd.color = vd.color;
	pd.uv = vd.uv;
	
	// Return result
	return pd;
}

//mxd. same as vs_main, but uses vertexColor var instead of actual vertex color. used in models rendering
PixelData vs_customvertexcolor(VertexData vd) 
{
	PixelData pd;
	
	// Fill pixel data input
	pd.pos = mul(float4(vd.pos, 1.0f), worldviewproj);
	pd.color = vertexColor;
	pd.uv = vd.uv;
	
	// Return result
	return pd;
}

LitPixelData vs_customvertexcolor_fog(VertexData vd) 
{
	LitPixelData pd;
	
	// Fill pixel data input
	pd.pos = mul(float4(vd.pos, 1.0f), worldviewproj);
	pd.pos_w.xyz = mul(float4(vd.pos, 1.0f), world).xyz;
	pd.pos_w.w = pd.pos.z;
	pd.color = vertexColor;
	pd.uv = vd.uv;
	pd.normal = vd.normal;
	
	// Return result
	return pd;
}

//mxd. light pass vertex shader
LitPixelData vs_lightpass(VertexData vd) 
{
	LitPixelData pd;
	pd.pos = mul(float4(vd.pos, 1.0f), worldviewproj);
	pd.pos_w.xyz = mul(float4(vd.pos, 1.0f), world).xyz;
	pd.pos_w.w = pd.pos.z;
	pd.color = vd.color;
	pd.uv = vd.uv;
	pd.normal = vd.normal;

	// Return result
	return pd;
}

// Normal pixel shader
float4 ps_main(PixelData pd) : COLOR
{
	float4 tcolor = tex2D(texturesamp, pd.uv);
	tcolor = lerp(tcolor, float4(stencilColor.rgb, tcolor.a), stencilColor.a);
	return tcolor * pd.color;
}

// Full-bright pixel shader
float4 ps_fullbright(PixelData pd) : COLOR
{
	float4 tcolor = tex2D(texturesamp, pd.uv);
	tcolor = lerp(tcolor, float4(stencilColor.rgb, tcolor.a), stencilColor.a);
	tcolor.a *= pd.color.a;
	return tcolor;
}

// Normal pixel shader with highlight
float4 ps_main_highlight(PixelData pd) : COLOR
{
	float4 tcolor = tex2D(texturesamp, pd.uv);
	tcolor = lerp(tcolor, float4(stencilColor.rgb, tcolor.a), stencilColor.a);
	if(tcolor.a == 0) return tcolor;
	
	// Blend texture color and vertex color
	float4 ncolor = tcolor * pd.color;
	
	return float4(highlightcolor.rgb * highlightcolor.a + (ncolor.rgb - 0.4f * highlightcolor.a), max(pd.color.a + 0.25f, 0.5f));
}

// Full-bright pixel shader with highlight
float4 ps_fullbright_highlight(PixelData pd) : COLOR
{
	float4 tcolor = tex2D(texturesamp, pd.uv);
	tcolor = lerp(tcolor, float4(stencilColor.rgb, tcolor.a), stencilColor.a);
	if(tcolor.a == 0) return tcolor;
	
	// Blend texture color and vertex color
	float4 ncolor = tcolor * pd.color;
	
	return float4(highlightcolor.rgb * highlightcolor.a + (tcolor.rgb - 0.4f * highlightcolor.a), max(pd.color.a + 0.25f, 0.5f));
}

//----------------------------------------------------------------------------------------------------------------------
// DC: calculations borrowed from PsyDoom to help accurately replicate PSX Doom in-game shading.
// Quantizes/truncates the given color to R5G5B5 in a way that mimics how the PS1 truncates color.
// Used to help reproduce the shading of the PlayStation.
//----------------------------------------------------------------------------------------------------------------------
float3 psxR5G5B5BitCrush(float3 color)
{
	// Note: I added a slight amount here to prevent weird rounding/precision issues.
	// This small bias prevents artifacts where pixels rapidly cycle between one 5-bit color component and the next.
	return trunc(color * 31 + 0.0001) / 31;
}

//----------------------------------------------------------------------------------------------------------------------
// DC: calculations borrowed from PsyDoom to help accurately replicate PSX Doom in-game shading.
// Compute the light diminishing multiplier for a pixel Z depth.
//----------------------------------------------------------------------------------------------------------------------
float getLightDiminishingMultiplier(float z)
{
	// Compute the basic light diminishing multiplier; a value of '128' means '1.0x' or no-change
	float intensity;

	if (LightMode == 1)
	{
		intensity = ((128.0 * 65536.0) / z) / 256.0;	// Walls
	}
	else if (LightMode == 2)
	{
		intensity = 160.0 - z * 0.5;	// Floors
	}
	else
	{
		intensity = 128.0;	// Things (no change)
	}

	// Clamp the intensity to the min/max allowed amounts (0.5x to 1.25x in normalized coords) and add a little
	// bias to fix precision issues and flipping back and forth between values when the calculations are close:
	intensity = trunc(clamp(intensity, 64.0, 160.0) + 0.0001);

    // Scale the diminish intensity back to normalized color coords rather than 0-128
    return intensity / 128.0;
}

//----------------------------------------------------------------------------------------------------------------------
// DC: calculations borrowed from PsyDoom to help accurately replicate PSX Doom in-game shading.
// Compute the color for a pixel, given the texture color, sector color, light level (integer) and z-depth of the pixel.
//----------------------------------------------------------------------------------------------------------------------
float4 doPsxDoomShading(float4 texColor, float4 sectorColor, float lightLevel, float z){
	// Convert input sector color to an integer value and modulate sector color by the light level (already an integer)
	sectorColor.rgb = sectorColor.rgb * 255.0;
	sectorColor.rgb = trunc((sectorColor.rgb * lightLevel) / 256.0);

	// Compute color multiply after accounting for sector light color and light diminishing effects and then normalize.
	// Add a little bias also to prevent switching back and forth between cases that are close, due to float inprecision.
	float3 colorMul = trunc(sectorColor.rgb * getLightDiminishingMultiplier(z) + 0.0001) / 128.0;

	// The PSX renderer doesn't allow the color multiply to go larger than this
	colorMul = min(colorMul, 255.0 / 128.0);

	// Make sure the input texture only uses 5-bit color to simulate the PlayStation's limitations.
	// It might be the case that the user is using 8-bit color (preview) textures to edit the level, which will later be
	// converted to the PlayStation's palette, which has 5-bit source color components. This truncation is an estimation
	// of how all these conversions might look...
	texColor.rgb *= 31;
	texColor.rgb = round(texColor.rgb);
	texColor.rgb /= 31;

	// Apply the color multiply and return the shaded pixel
	return float4(texColor.rgb * colorMul, texColor.a);
}

// mxd. This adds fog color to current pixel color.
// DC: removed fog to simplify the shading since it is not something that is used in-game.
float4 getFogColor(LitPixelData pd, float4 texColor, float4 sectorColor)
{
	float4 color;
	
	if (LightMode != 0)
	{
		color = doPsxDoomShading(texColor, sectorColor, LightLevel, pd.pos_w.w);
	}
	else
	{
		color = texColor;
	}

	return float4(psxR5G5B5BitCrush(color.rgb), color.a);	// DC: bit crush to simulate the PlayStation's limitations
}

//mxd. Shaders with fog calculation
// Normal pixel shader
float4 ps_main_fog(LitPixelData pd) : COLOR 
{
	float4 tcolor = tex2D(texturesamp, pd.uv);
	tcolor = lerp(tcolor, float4(stencilColor.rgb, tcolor.a), stencilColor.a);
	if(tcolor.a == 0) return tcolor;
	
	return getFogColor(pd, tcolor, pd.color);
}

// Normal pixel shader with highlight
float4 ps_main_highlight_fog(LitPixelData pd) : COLOR 
{
	float4 tcolor = tex2D(texturesamp, pd.uv);
	tcolor = lerp(tcolor, float4(stencilColor.rgb, tcolor.a), stencilColor.a);
	if(tcolor.a == 0) return tcolor;
	
	// Blend texture color and vertex color
	float4 ncolor = getFogColor(pd, tcolor, pd.color);
	
	return float4(highlightcolor.rgb * highlightcolor.a + (ncolor.rgb - 0.4f * highlightcolor.a), max(ncolor.a + 0.25f, 0.5f));
}

//mxd: used to draw bounding boxes
float4 ps_constant_color(PixelData pd) : COLOR 
{
	return vertexColor;
}

//mxd: used to draw event lines
float4 ps_vertex_color(PixelData pd) : COLOR 
{
	return pd.color;
}

//mxd. dynamic light pixel shader pass, dood!
float4 ps_lightpass(LitPixelData pd) : COLOR
{
	//is face facing away from light source?
	// [ZZ] oddly enough pd.normal is not a proper normal, so using dot on it returns rather unexpected results. wrapped in normalize().
	//      update 01.02.2017: offset the equation by 3px back to try to emulate GZDoom's broken visibility check.
	float diffuseContribution = dot(normalize(pd.normal), normalize(lightPosAndRadius.xyz - pd.pos_w.xyz + normalize(pd.normal)*3));
	if (diffuseContribution < 0 && ignoreNormals < 0.5)
		clip(-1);
	diffuseContribution = max(diffuseContribution, 0); // to make sure

	//is pixel in light range?
	float dist = distance(pd.pos_w.xyz, lightPosAndRadius.xyz);
	if(dist > lightPosAndRadius.w)
		clip(-1);

	//is pixel tranparent?
	float4 tcolor = tex2D(texturesamp, pd.uv);
	tcolor = lerp(tcolor, float4(stencilColor.rgb, tcolor.a), stencilColor.a);
	if(tcolor.a == 0.0f)
		clip(-1);

	//if it is - calculate color at current pixel
	float4 lightColorMod = float4(0.0f, 0.0f, 0.0f, 1.0f);

	lightColorMod.rgb = lightColor.rgb * max(lightPosAndRadius.w - dist, 0.0f) / lightPosAndRadius.w;
    
    if (spotLight > 0.5)
    {
        float3 lightDirection = normalize(lightPosAndRadius.xyz - pd.pos_w.xyz);
        float cosDir = dot(lightDirection, lightOrientation);
        float df = smoothstep(light2Radius.y, light2Radius.x, cosDir);
        lightColorMod.rgb *= df;
    }

	if (lightColor.a > 0.979f && lightColor.a < 0.981f) // attenuated light 98%
		lightColorMod.rgb *= diffuseContribution;
	if (lightColorMod.r > 0.0f || lightColorMod.g > 0.0f || lightColorMod.b > 0.0f)
	{
		lightColorMod.rgb *= lightColor.a;
		if (lightColor.a > 0.4f) //Normal, vavoom or negative light (or attenuated)
			return tcolor * lightColorMod;
		return lightColorMod; //Additive light
	}
	clip(-1);
	return lightColorMod; //should never get here
}

//mxd. Vertex skybox shader
SkyPixelData vs_skybox(SkyVertexData vd)
{
	SkyPixelData pd;
	pd.pos = mul(float4(vd.pos, 1.0f), worldviewproj);
	float3 worldpos = mul(float4(vd.pos, 1.0f), world).xyz;
	pd.tex = reflect(worldpos - campos.xyz, normalize(mul(skynormal, world).xyz));
	return pd;
}

//mxd. Pixel skybox shader
float4 ps_skybox(SkyPixelData pd) : COLOR
{
	float4 ncolor = texCUBE(skysamp, pd.tex);
	return float4(highlightcolor.rgb * highlightcolor.a + (ncolor.rgb - 0.4f * highlightcolor.a), 1.0f);
}

// Technique for shader model 2.0
technique SM20 
{
	// Normal
	pass p0 
	{
		VertexShader = compile vs_2_0 vs_main();
		PixelShader = compile ps_2_0 ps_main();
	}
	
	// Full brightness mode
	pass p1 
	{
		VertexShader = compile vs_2_0 vs_main();
		PixelShader = compile ps_2_0 ps_fullbright();
	}

	// Normal with highlight
	pass p2 
	{
		VertexShader = compile vs_2_0 vs_main();
		PixelShader = compile ps_2_0 ps_main_highlight();
	}
	
	// Full brightness mode with highlight
	pass p3 
	{
		VertexShader = compile vs_2_0 vs_main();
		PixelShader = compile ps_2_0 ps_fullbright_highlight();
	}
	
	//mxd. same as p0-p3, but using vertexColor variable
	// Normal
	pass p4 
	{
		VertexShader = compile vs_2_0 vs_customvertexcolor();
		PixelShader = compile ps_2_0 ps_main();
	}
	
	//mxd. Skybox shader
	pass p5 
	{
		VertexShader = compile vs_2_0 vs_skybox();
		PixelShader  = compile ps_2_0 ps_skybox();
	}
	
	// Normal with highlight
	pass p6 
	{
		VertexShader = compile vs_2_0 vs_customvertexcolor();
		PixelShader = compile ps_2_0 ps_main_highlight();
	}

	pass p7 {} //mxd. need this only to maintain offset
	
	//mxd. same as p0-p3, but with fog calculation
	// Normal
	pass p8 
	{
		VertexShader = compile vs_2_0 vs_lightpass();
		PixelShader = compile ps_2_0 ps_main_fog();
	}
	
	pass p9 {} //mxd. need this only to maintain offset

	// Normal with highlight
	pass p10 
	{
		VertexShader = compile vs_2_0 vs_lightpass();
		PixelShader = compile ps_2_0 ps_main_highlight_fog();
	}

	pass p11 {} //mxd. need this only to maintain offset
	
	//mxd. same as p4-p7, but with fog calculation
	// Normal
	pass p12 
	{
		VertexShader = compile vs_2_0 vs_customvertexcolor_fog();
		PixelShader = compile ps_2_0 ps_main_fog();
	}

	pass p13 {} //mxd. need this only to maintain offset
	
	// Normal with highlight
	pass p14 
	{
		VertexShader = compile vs_2_0 vs_customvertexcolor_fog();
		PixelShader = compile ps_2_0 ps_main_highlight_fog();
	}

	//mxd. Used to render event lines
	pass p15
	{
		VertexShader = compile vs_2_0 vs_main();
		PixelShader  = compile ps_2_0 ps_vertex_color();
	}
	
	//mxd. Just fills everything with vertexColor. Used in ThingCage rendering.
	pass p16 
	{
		VertexShader = compile vs_2_0 vs_customvertexcolor();
		PixelShader  = compile ps_2_0 ps_constant_color();
	}
	
	//mxd. Light pass
	pass p17 
	{
		VertexShader = compile vs_2_0 vs_lightpass();
		PixelShader  = compile ps_2_0 ps_lightpass();
		AlphaBlendEnable = true;
	}
}
