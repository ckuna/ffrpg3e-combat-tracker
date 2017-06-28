# ffrpg
The purpose of the application is to help ease some of the complications of managing an ffrpg3e play session, specifically combat-tracking, and pc rewards. The application tries to randomize a lot of the enemy stats and item drops to allow the GM to focus on creating the experience. The player handbook can be found here: http://ffrpg.net/ffrpg/

## Dependencies
The application requires .NET 4.5

## Using The Application
### The Interface
The Enemy Tab was designed to keep current enemies visible for a combat session. The main view of the application has the combat tracker, as well as the accrued experience for a combat session.
<p align="center"><img src="https://user-images.githubusercontent.com/26715874/27661486-74c77a40-5c28-11e7-96c7-982f23d85251.png" width="700px"/></p>
The Item Tab was designed as a secondary feature, to allow GMs to randomize treasure-chests, "build shops", and view a comprehensive list of the game's items.
<p align="center"><img src="https://user-images.githubusercontent.com/26715874/27661485-74c47cfa-5c28-11e7-95db-d47277a406af.png" width="700px"/></p>

### Creating Enemies
Creating enemies in ffrpg3e is no joke. It takes a long time, so you can imagine "random" encounters don't just grow on trees for a GM. However, this tries to follow the rules for generating enemies (with the exception of abilities).

#### Enemy Base
Starting with the base stats, the Gm is able to define the particular stengths and weaknesses as well as the type modifier.

<p align="center"><img src="https://user-images.githubusercontent.com/26715874/27661479-74afb310-5c28-11e7-8fb0-2c1613656561.png" width="700px"/></p>

#### Enemy Stats

After the enemies base type and modifiers have been determined, it's time to calculate the stats. This would be the time consuming part if it weren't for a little help from software.
1. Select the preferred stat to lean toward during "random" stat allocation
2. Click "Randomize Attributes"
3. If you're satisfied with the generated attributes, Click "Calculate Combat Stats"

<p align="center"><img src="https://user-images.githubusercontent.com/26715874/27661483-74be62ac-5c28-11e7-94da-378fcb2b114b.png" width="700px"/></p>

#### Enemy Magic

Selecting magic for enemies is easy. Just switch tabs between the three different magic types, select the one you want, and click "Add". The application will add the selected magic to the enemy. If you changed your mind, select the one you don't want and click "Remove".

<p align="center"><img src="https://user-images.githubusercontent.com/26715874/27661484-74c3fff0-5c28-11e7-9f6c-fc6861f00cee.png" width="700px"/></p>

#### Create Enemies

You're almost done! Name the enemy and select a quantity to add to the "Active Enemy List"! Once you're done Click "Create Monster".
Note: The application doesn't automatically clear the enemy, in case you need to add more after the fact.

<p align="center"><img src="https://user-images.githubusercontent.com/26715874/27661481-74bcdf0e-5c28-11e7-8d9b-1f573730218a.png" width="700px"/></p>

#### Active Enemies

Look at that! You are now the proud owner of your own active enemies!

<p align="center"><img src="https://user-images.githubusercontent.com/26715874/27661480-74bd004c-5c28-11e7-96e2-7dc97ae91ee5.png" width="700px"/></p>

### Managing Active Enemies
After selecting an active enemy their attributes and combat statistics will be presented. Here there are a few different things to do.
1. Add/Remove Status Effects
2. Execute damage against Armor, M. Armor, unmitigated damage, and healing
3. Add/Subtract MP
4. Cast Magic (Reducing MP)
5. End the round (Resolving status effects)

<p align="center"><img src="https://user-images.githubusercontent.com/26715874/27661489-74c91df0-5c28-11e7-81bf-e22ba5b3a048.png" width="700px"/></p>

#### Status Effects
To add a status effect, select the dropdown menu and pick your poison... get it?

<p align="center"><img src="https://user-images.githubusercontent.com/26715874/27661490-74ccd378-5c28-11e7-903c-d987118e27ed.png" width="700px"/></p>

After selecting the desired effect, enter the duration (in rounds). Once entered, click "Add".

<p align="center"><img src="https://user-images.githubusercontent.com/26715874/27661491-74d15844-5c28-11e7-9529-2e37cd35ff13.png" width="700px"/></p>

You're added status effects will be shown beneath enemy HP/MP. Note: "Round End" will resolve some statuses like Regen, Poison, Venom, but not all of them.

<p align="center"><img src="https://user-images.githubusercontent.com/26715874/27661495-74d480dc-5c28-11e7-9e5c-33416c573481.png" width="700px"/></p>

#### Casting Magic
The spells that were added during creation, are now usable. Clicking "Cast" removes the mp cost from the enemies total MP.

<p align="center"><img src="https://user-images.githubusercontent.com/26715874/27661493-74d2fcee-5c28-11e7-8169-eadca5773985.png" width="700px"/></p>

#### Resolving Damage
* When an enemy takes damage, they sometimes have the ability to soak all or a portion of that damage. Select the desired "defensive soak" enter in a numeric value and click "Execute". This will remove the appropriate amount of HP from the enemy, taking into account their armor or m. armor.
* Subtract/Add MP is just to handle the osmose spell. That is all.
* Round End resolves the status effects that have been added to the enemy.

<p align="center"><img src="https://user-images.githubusercontent.com/26715874/27661492-74d19fac-5c28-11e7-899c-57dbcd3f9b75.png" width="700px"/></p>

#### Killing Enemies
* Enemies can be killed by the "Kill" button or after receiving an amount of damage that drops their HP below 0.
* The enemy drops gil and exp that is calculated during the building process.
* Killing enemies may also afford a random item from the monster's loot table.

<p align="center"><img src="https://user-images.githubusercontent.com/26715874/27661494-74d3022a-5c28-11e7-8346-1633c732f87a.png" width="700px"/></p>

* The loot table is on the items tab, if the PCs forget to loot the enemies, the items are lost when "Clear" is clicked.

<p align="center"><img src="https://user-images.githubusercontent.com/26715874/27661496-74d82976-5c28-11e7-9c93-3ed39218f6de.png" width="700px"/></p>

* Splitting the exp and gil reward is definitely a good idea. Enter a "Party Size" and click "Split" to do the division.

<p align="center"><img src="https://user-images.githubusercontent.com/26715874/27661497-74da9288-5c28-11e7-9eff-9d8b05326711.png" width="700px"/></p>

### Item Shop
The item shop is pretty basic. It was designed to just organize the mass amounts of information in the ffrpg3e pdf, randomize what's inside treasure chests, and generate a user shopping experience.

#### Random Treasure
Clicking "Open" picks a number of items, determines their rarity, and adds them to the treasure-list. The rarity is dependent on the party's level so, not much more I could do here...

<p align="center"><img src="https://user-images.githubusercontent.com/26715874/27661482-74bd7176-5c28-11e7-8366-9f548e469943.png" width="700px"/></p>

#### Item List
The item list organizes all of the items in the ffrpg3e player guide. This is useful when you're determining what a "Uncommon Armor" might be for the PC's level.

<p align="center"><img src="https://user-images.githubusercontent.com/26715874/27661487-74c79ba6-5c28-11e7-8a85-f033f9dee898.png" width="700px"/></p>

#### Shop Keeper
The shop keeper filters the list of items based on an availability level. If the party has found a final fantasy walmart, the availability will be lower. Enter the availability in the bottom left, and click "Build Shopping Experience" to filter the items to that availability.

<p align="center"><img src="https://user-images.githubusercontent.com/26715874/27661488-74c826c0-5c28-11e7-828a-99f305e65d84.png" width="700px"/></p>
