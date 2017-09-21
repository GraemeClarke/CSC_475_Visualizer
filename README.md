# cube.space
An audio visualizer project intially designed for CSC 475 - Musicial Information Retrieval Techniques - continually being further developed. <br />

![alt text](https://github.com/GraemeClarke/CSC_475_Visualizer/blob/master/sample_images/Sphere_Cubes.png "Sphere Cubes")

## How to run:
Download project .zip to run on macOS, Windows (untested) or Linux (untested).

For quick-launch/viewing, run "cube.space (demo version)". 

-Mac: cube.space (demo version).app
<br />
-Windows: cube.space(demo version).exe
<br />
-Linux: cube.space(demo version).x86
<br />

The "demo version" contains a pre-selected list of songs, and the "mic version" uses built-in microphone input to create visualizations.

To run wav file input version, run "cube.space (wav version)" located in the folder "WAV Reading Version". This application file can be ran in any directory that has wave files, and it will recognize/visualize them in sort order. Note that this version is experimental, music is unpausable and wont be played until initial hitting of **space** key. 

![alt text](https://github.com/GraemeClarke/CSC_475_Visualizer/blob/master/sample_images/Tunnel_Scale.png "Tunnel Scale")


## Controls
-**Left/Right:** Change song.
<br />
-**Up/Down:** Change visualizer.
<br />
-**Space:** Play/Pause
<br />
-**H:** Show/hide song/visualizer title.
<br />
-**J:** Enable/disable "auto swap" between visualizers.
<br />
<br />

![alt text](https://github.com/GraemeClarke/CSC_475_Visualizer/blob/master/sample_images/Spectogram_Circle.png "Spectogram_Circle")


## Visualizations Included (In order of appearance) 
*Tunnel_Scale:* Continuous rings composed of 70 cubes each move towards the screen while being uniformly scaled based on audio input (sample). 
<br /><br />
*Tunnel_Transform:* Continuous rings composed of 80 cubes each move towards the screen while being transformed towards the "center" of the ring based on audio input (sample). 
<br /><br />
*Spectogram_Line:* A standard spectogram visualization that transforms a line of 30-cubes vertically based on audio input, while a second line of cubes move/fall based on real-time physics.
<br /><br />
*Spectogram_Line_Flow:* A spectogram visualization that places 30-cube lines based on audio input (sets height), then transforms them towards a deletion point.
<br /><br />
*Spectogram_Circle:* A spectogram visualization that transforms the height of a circle of 30 cubes vertically based on audio input. A second circle of cubes move/fall based on real-time physics.
<br /><br />
*Sphere_Cubes:* A spectogram visualization that places 250 cubes in the shape of a sphere, transforming them towards the center of the sphere based on audio input.
<br /><br />
*Sphere_Spheres:* A spectogram visualization that places 250 spheres in the shape of a sphere, transforming them towards the center of the sphere based on audio input.
<br /><br />
*Sphere_Cubes_75:* A modified version of Sphere_Cubes that uses 70 cubes instead of 250, thus using less audio samples and favouring lower frequencies.
<br /><br />
*Spectogram_Line_1024:* A modified version of Spectogram_Line that visualizes based on every single sample in a given audio file (experimental)
<br /><br />
*Spectogram_Line_1024_Balanced:* A modified version of Spectogram_Line_1024 that linearly scales up higher frequencies in an attempt to give a more "balanced" visualization (experimental)
<br /><br />
*Spectogram_Line_Avg:* A modified version of Spectogram_Line_1024 that averages/divides each bin at a sample rate of 1024 into 100 cubes, and scales accordingly.
