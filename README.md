# Tower Defence
This tower defence demo features a bunch of different mushroom enemies marching towards the heart at the center of the screen, which the player must protect. The towers can be placed on grass, but cannot overlap with one another. Upgrades can be made to their firerate, projectile speed, and damage.

![ the Tower-Defence_Gameplay](https://github.com/chrisilly/TowerDefence/assets/103900975/c7b39c6d-c6e2-4438-9855-2bd17d41a91b)

# Enemies
![enemySpritesheet](https://github.com/chrisilly/TowerDefence/assets/103900975/aec34e12-2cf0-4b17-a144-daee6890fb75)
![enemyHurtSpritesheet](https://github.com/chrisilly/TowerDefence/assets/103900975/1f3064d4-f64a-497b-8c81-7ecae476e0b0)

All enemies share the same sprite and class but vary in colour and behaviours. Instead of relying on inheritance, they are kept in order with the help of interfaces and dependency injection. I chose this approach experimentally after watching CodeAesthetic's video on [The Flaws of Inheritance](https://youtu.be/hxGOiiR9ZKg?si=AHM-9uBYRAmVvWwa) to learn more about compositional approaches.
- Red enemies will lose their hat upon being hit, and will be defeated upon a second hit
- Blue enemies run faster than red ones, but will be defeated in only one hit
- Green enemies take three hits to defeat, but are very slow
- Pink enemies look and act similar to red enemies, but will become enraged and sprint after being hit
