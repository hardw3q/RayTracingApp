#version 330

struct SCamera {
    vec3 Position;
    vec3 View;
    vec3 Up;
    vec3 Side;
    vec2 Scale;
};

struct SRay {
    vec3 Origin;
    vec3 Direction;
};

uniform SCamera uCamera;

in vec3 gPosition;
out vec4 FragColor;

SRay GenerateRay()
{
    vec2 coords = gPosition.xy * uCamera.Scale;
    vec3 direction = uCamera.View + uCamera.Side * coords.x + uCamera.Up * coords.y;
    return SRay(uCamera.Position, normalize(direction));
}

void main()
{
    SRay ray = GenerateRay();
    FragColor = vec4(abs(ray.Direction.xy), 0, 1.0);
}