# RigidbodyFixer
This set of scripts is a temporary solution to the problem https://issuetracker.unity3d.com/issues/transform-dot-position-values-becomes-to-nan-when-one-gameobject-rotates-while-colliding-the-edge-of-another-gameobject<br>
After numerous checks, it was found out that in some cases, in the OnCollisionEnter and OnTriggerEnter methods, the objects that are interacted with have Rigidbody with Vector3 having NaN values. These can be position, rotation, velocity, etc.<br>
The methods suggested on the bug page did not help. Legacy physics, disabling Convex (in my project Mesh Collider is not used at all), etc.<br>
Initially, I tried to check the parameters for NaN and fix them in the OnCollisionEnter and OnTriggerEnter methods themselves. However, this caused strong FPS drawdowns.<br>
Therefore, I switched to another option: performing checks and fixing on all Rigidbody. And, so that there were no problems with FPS, I used https://github.com/Leopotam/ecs
<hr>
<br>You need to install LeoECS in the project, add the RigidbodyFixerLauncher component to the problem scene.
