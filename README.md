# Run!
#### Video Demo:  <https://youtu.be/510zA2zirOA>
#### Description:
Inspired by the [CoolMathGames version](https://www.coolmathgames.com/0-run), my version of Run! is 3-dimensional interactive game where the player has to strategize the best way of survival: through jumping and dodging obstacles that has surfaced the map.

#### **Instructions**
- Use the **right and left arrow keys** to *move the sphere around the map*. There are constraints added on the map in order for the player to not fall off of the side of the map.
- Use the **space bar** to *jump* over the gaps and dodge obstacles throughout the map
- Use the **up arrow key** to *invert the gravity*. This feature allows one to play the game upside down or downside up.

#### **Challenging Rule!**
- The player cannot jump or invert the gravity when the sphere is midair

*This is a never-ending game as it automatically resets when the player died, which makes it a continuous game of survival.*

**Technology used:** *Unity Hub (ver 2020.3.23f1 lts), Visual Studio Code 2019*

### **Description of the Scripts**
#### `MoveSphere.cs`
- The code begins with several import statements, including the necessary Unity and UnityEngine libraries for accessing various Unity functionalities.

- The `MoveSphere` class is defined, which inherits from the `MonoBehaviour` class. This class represents the script that controls the movement of the sphere.

- The class contains several member variables, including `rb` (a reference to the Rigidbody component of the sphere), `mainCamera` (a reference to the main camera in the scene), `ground1` and `ground2` (boolean flags to determine if the sphere is on the first or second ground), `invert` (a boolean flag to indicate if gravity is inverted), `isRotated` (a boolean flag to track if the camera rotation has occurred), `count` (an integer variable to count the number of jumps performed), `anim` (a reference to the Animation component of the main camera), and `audio` (a reference to the AudioSource component of the sphere).

- The `Start()` function is called before the first frame update. It initializes the member variables by obtaining references to various components, setting initial values for boolean flags, and initializing the count to zero.

- The `Update()` function is called once per frame. It contains the main logic for controlling the sphere's movement and handling user input.

- Inside the `Update()` function, there are several lines of code to move the main camera and the sphere forward using the Translate function.

- The code checks if the sphere is on the ground by comparing its y-coordinate with certain thresholds. The `ground1` and `ground2` flags are updated accordingly.

- If the sphere falls below a certain threshold or goes above a certain threshold, the code checks if gravity inversion is enabled (`invert` flag) and reloads the current scene using `SceneManager.LoadScene()` function. This effectively restarts the game.

- The code checks for user input using `Input.GetKey()` and `Input.GetKeyDown() `functions. If the right or left arrow keys are pressed, and the count is zero (indicating no jumps are in progress), the sphere is moved right or left accordingly.

- If the space key is pressed, the audio attached to the sphere is played, and if the sphere is on the first or second ground, a force is added to make it jump up or down, respectively.

- If the up arrow key is pressed, the audio is played, and if the sphere is on the ground and not currently jumping, the invert flag is toggled, the camera rotation is reset (`isRotated` flag is set to false), and the gravity direction is inverted using `Physics.gravity`.

- If the `invert` flag is true, and the `count` is greater than zero, the code checks if the camera rotation is not 180 degrees. If it's not, an animation is played on the camera to rotate it, and the `isRotated` flag is set to true. This ensures that the rotation animation is played only once.

- Inside the `invert` block, if the right or left arrow keys are pressed, and the `count` is greater than zero, the sphere is moved in the opposite direction (left or right) compared to the normal gravity orientation.

- If the `invert` flag is false, and the `count` is greater than zero, the code checks if the camera rotation is not 0 degrees. If it's not, an animation is played on the camera to rotate it, and the isRotated flag is set to true.

- The code includes a `void OnCollisionEnter(Collision collision)` function, which is called when the sphere collides with another object. In this case, if the collided object has the name "Cube(Clone)" (indicating a collision with a specific cube object), the code checks if gravity inversion is enabled (`invert` flag) and reloads the current scene using `SceneManager.LoadScene()`. This is done to restart the game when the sphere collides with the cube.


*tl;dr*
 It controls the movement of a sphere in a Unity game, allowing it to move forward, jump, and change direction based on user input. It also includes functionality for gravity inversion and scene reloading upon collision with a specific object.

#### `Spawn.cs`
- The code begins with several import statements, including the necessary Unity and UnityEngine libraries for accessing various Unity functionalities.

- The `Spawn` class is defined, which inherits from the `MonoBehaviour` class. This class represents the script responsible for spawning objects.

- The class contains several member variables. It includes references to various game objects, such as `plane1`, `plane2`, ..., `plane5` (representing normal planes), `iplane1`, `iplane2`, ..., `iplane5` (representing inverted planes), and `wall` (representing a wall object). It also includes two lists, `normList` and `invList`, which will store the instantiated instances of the plane objects. Additionally, there are `timer` and `timer2` variables to track time.

- The `Start()` function is called before the first frame update. It initializes the pos variable to the z-coordinate of `plane1` plus 45 (to determine the initial position of the spawned objects). It then instantiates the normal planes and inverted planes, adding them to their respective lists.

- The `Update()` function is called once per frame. It contains the main logic for spawning objects at specified intervals.

- Inside the `Update()` function, the `timer` and `timer2` variables are incremented by `Time.deltaTime` to measure elapsed time.

- If the `timer` reaches or exceeds 0.8 seconds, it indicates that it's time to spawn new planes. A random number (`num1`) between 0 and 4 is generated to determine which plane in the `normList` will not be instantiated. Another random number (`num2`) between 0 and 4 is generated to determine which plane in the `invList` will not be instantiated.

- Two for loops iterate over the planes in `normList` and `invList` respectively. In each iteration, if the current index (`x`) is not equal to `num1`, the plane's position is updated to the new `pos` value, and a new instance of the plane is instantiated at that position. If the current index is equal to `num1`, only the plane's position is updated.

- Similarly, in the second for loop, if the current index (`x`) is not equal to `num2`, the inverted plane's position is updated to the new `pos` value, and a new instance of the inverted plane is instantiated at that position. If the current index is equal to `num2`, only the inverted plane's position is updated.

- After spawning the planes, the `timer` is reset to 0.

- If the `timer2` reaches or exceeds 3 seconds, it indicates that it's time to spawn walls. Two random numbers (`wallNum1` and `wallNum2`) between -9 and 9 are generated to determine the x-coordinate of the wall's position. Two walls are instantiated with the respective coordinates and the current `pos` value.

- After spawning the walls, the `timer2` is reset to 0.

*tl;dr*
It manages the spawning of planes and walls in a Unity game based on time intervals and randomization.

##### **Assets Imported**
- Camera animation
    - Non-invert movement
    - Invert movement
- Color Dark Blue and Purple
- Cube prefab
- Sphere prefab
- Music Tracks
- Scenes
- Free Pack (For the jumping and inverting sound effect)
- SkySerie Freebie
