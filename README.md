# cube.space
Audio visualizer project designed intially for CSC 475 - Musicial Information Retrieval Techniques. Continually being developed. <br />

## How to run:
Download .zip to run on macOS, Windows (Untested), or Linux (Untested).

For quick-launch/viewing, run "cube.space (demo version)". 

To run wav file input version, run "cube.space (wav version)" from within the "WAV Reading Version" folder. Note that this version is experimental, music is unpausable and wont be played until initial hitting of **space** key. 


## Controls
-**Left/Right:** Change song.
<br />
-**Up/Down:** Change visualizer.
<br />
-**Space:** Play/Pause
<br />
-**H:** Show/hide song/visualizer title.
<br />
<br />

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
