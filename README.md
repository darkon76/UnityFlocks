# UnityFlocks

Quick example of flock behavior using boids.

The boids can flock, avoid obstacles, detect enemies and follow a target. 

They have the most basic behaviors, Aligment, Cohesion and Separation, The obstacle avoidance is a simple cockroach detection( I dont remember the official name).
Following the target is just a rotation nothing fancy. 

The project has only one scene. 

At the hierachy are 3 main objects.

**FollowTheLeader** 5 blue boids following the leader.

**OrangeSpawner** Spawn 50 boids that try to flock. 

**FightingTeams** 5 blue boids vs 5 red boids, need to add lasers, 

Some images.
http://imgur.com/a/HKTjk

#Note#
If you activate the FollowTheLeader and FightingTeams,if a squadmate detects an enemy, it will start attacking it.
If the squadmate can't detect any enemy it will start following you again. 

**Important**

The project isn't optimized. 

Images at 




