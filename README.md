
# 2D_FPS_GJ
A 2D Retro/Boomer Shooter developed in Unity 
## Contents

1. [ Description ](#description)
2. [ GDD ](#gdd)
3. [ Changelog ](#changelog)


<a name="description"></a>
## 1. Description
#### What is this project and why does it exist?
**TEMP** - Description of the project


<a name="gdd"></a>
## 2. GDD

**TEMP** - Create and upload a Game Design Document.


<a name="changelog"></a>
## 3. Changelog

Changelog Legend :

- <span style="color:green">**Green**</span> -  Version successful with no known issues;
- <span style="color:gold">**Yellow**</span> -  Version successful with few known issues;
- <span style="color:orange">**Orange**</span> -  Version partially successful with a couple of known/unknown issues;
- <span style="color:red">**Red**</span> -  Version partially successful with many known/unknown issues;
- <span style="color:black">**Black**</span> -  Version failed;
<br/><br/>

>## 0.0.1
>11/20/2021 • 6:55AM GMT+1
> <span style="color:green">**Green**</span>
>
>Added temporary assets and character controller script.
<br/><br/>

>## 0.0.2
>11/20/2021 • 6:55AM GMT+1
> <span style="color:green">**Green**</span>
>
>Added a test wall and colliders, both to the wall and the player.
<br/><br/>
>## 0.0.3
>11/20/2021 • 8:14AM GMT+1
> <span style="color:green">**Green**</span>
>
>Added a shooting mechanic based on Raycast, and a 3D Box collider on the wall model so that it interacts with the shooting raycast.
>
>Also added a visual effect on hit.
<br/><br/>

>## 0.0.4
>11/20/2021 • 10:35AM GMT+1
> <span style="color:green">**Green**</span>
>
>Added a 2D gun sprite to the UI, awith a shooting animation.
>
>Also added ammo items, that can be picked up and gives the player n amout of bullets.
<br/><br/>

>## 0.0.5
>11/20/2021 • 11:23AM GMT+1
> <span style="color:green">**Green**</span>
>
>Added an enemy with a script attached to it. The enemy can chase the Player if he/she is in range. The enemy can be killed(with death animation).
<br/><br/>

>## 0.0.6
>11/22/2021 • 5:10AM GMT+1
> <span style="color:green">**Green**</span>
>
>- Added enemy shooting mechanic (When he gets in range, he start shooting. Can be a non shooting enemy as well).
>- Enemy bullet system, it is shot towards the player.
>- Health system, player takes dmg from enemy bullet.
<br/><br/>

>## 0.0.7
>11/22/2021 • 7:18AM GMT+1
> <span style="color:green">**Green**</span>
>
>- Fixed issues with ammo & health pickup where ammo count could go negative and healthpickups could oveheal the player.
>- Hiden mouse cursor during gameplay, escape to bring it back.
<br/><br/>

>## 0.0.8
>11/22/2021 • 10:42AM GMT+1
> <span style="color:green">**Green**</span>
>
>- Added head bubbing during movement of the player.
<br/><br/>

>## 0.0.9
>11/23/2021 • 5:07AM GMT+1
> <span style="color:green">**Green**</span>
>
>- Implemented Tilemap to use as level creator and editor.
>- Added a second material to the wall asset, adding more details and an illusion of depth of the level.
<br/><br/>

>## 0.1.0
>11/23/2021 • 5:41AM GMT+1
> <span style="color:green">**Green**</span>
>
>- Added a functioning door.
<br/><br/>

>## 0.1.1
>11/23/2021 • 7:06AM GMT+1
> <span style="color:green">**Green**</span>
>
>- Added an AudioController.
>- Added sounds for ammoPickup, healthPickup, enemyDeath, enemyShot, gunShot, playerHurt.

> This concludes the Tutorial. The project has reached the same point as in the tutorial, but with a few bug fixes and improvements, such as: 
>- Camera clipping through walls when near them;
>- You can not fire bullets if you are left without any bullets;
>- Ammo count stops at 0 (initially you could fire even without any bullets left, dealing no damage but triggering the gun shooting animation and makgin the currentAmmo go to negative values);
>- HealthPickups do not overheal the player (initially, healthPickups would add more hit points to the player, going over 100hp);
<br/><br/>

>## 0.1.2
>11/24/2021 • 4:23AM GMT+1
> <span style="color:gold">**Yellow**</span>
> As of this update, multiple bug fixes are to be expected.
>
>- Substituted multiple lines of code with a function in the AudioController and referenced it in other scripts.
>- Added a camera restriction with MatfClamp so that the player can not rotate the camera 360* on the Y axis (Z axis in our case).
<br/><br/>

>## 0.1.3
>11/24/2021 • 12:30AM GMT+1
> <span style="color:gold">**Yellow**</span>
>
>- Added DestroyBulletOverTime. In case the lvls are open spaces and the bullets don't hit anything, instead of flying into oblivion, they will get destroyed after 15 seconds.
-Made so that bullets would not be able to pass through walls.
<br/><br/>
