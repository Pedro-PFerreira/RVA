# CapiDefenders (Final Grade: 16.3/20)

## Group members

- Lourenço Alexandre Correia Gonçalves (202004816, up202004816@up.pt);
- Pedro Manuel Costa Aguiar Botelho Gomes (202006086, up202006086@up.pt);
- Pedro Pereira Ferreira (202004986, up202004986@up.pt).

## Game Description

CapiDefenders is a AR (Augmented Reality) game where the player has to defend a big, golden capybara from waves of stegosaurus. The player can place characters by using a deck of cards to fight the enemies, as well as spells with magic powers. The game is over when the golden capybara is destroyed.

## Technologies used

In order to develop the game, it was used Unity and Vuforia engine plug-in to create the AR experience. In addition to it, Blender was used to create some of the 3D models of the game, such as the wizard hat, the tornado, and the lightning. The game was developed for Android devices.

## The Deck of Cards

All the game characters except the evil stegossaurs can be summoned using the deck of cards. Each have their own mechanics and characteristics. Below are specified the mechanics for each card, as well as the appearance of the card and character and the link for the model used for the character.

### Golden Capybara
The Golden Capybara is a big and sacred capybara that must defended and kept alive in order to win the game. If it's health reaches 0, the game is over. Other than that, the Golden Capybara doesn't do much.
- **Model:** https://sketchfab.com/3d-models/capybara-by-ao-inomata-3e8ec79c8666456d9aeb747d722f6c48

### Capybara Soldiers
Capybara Soldiers are melee fighters that will punch nearby enemies in any direction they can. They are good for being positioned in points enemies will have to run across, to ensure they get hit by them.
- **Model:** https://sketchfab.com/3d-models/stumble-guys-capybara-f807a741b81f4740b2178e9302a2a726

### Capybara Wizard
Capybara Wizards throw lightning spells towards the direction they are facing. When positioned on the game area, rotating the card rotates the direction they are facing. They allow for attacking enemies from a certain range.
- **Model:** (model is the same used for the Soldier Capybara, but its hat was hand-made on Blender).

### Wall
Walls are used to block the path to the Golden Capybara for enemies, forcing them to go around them and making them take longer to damage the Golden Capybara and your other cards. It's possible to change the wall's orientation by rotating the card.
- **Model:**

### Tornado Spells
Tornados are one time spells that pull enemies in the area towards its center while damaging them. You can only use each tornado spell card once per match.
- **Model:**

### Fire Spells
Fire spells are one time spells that damage enemies in the area for a short period of time. You can only use each fire spell card once per match.
- **Model:** https://sketchfab.com/3d-models/fire-8161ae32b81446b397a0efcd36796753

## How to execute the project

### Prerequisites

To execute the project it is mandatory to have an Android device, with Android 8.0 Oreo as minimum version.

### Instructions

In order to execute the project, it is only need to run the project's executable on an Android device.

## Features

- The player can place troopers and spells up to 3 at a time, by using the respective markers;

- The player can rotate the camera and see the game from different angles, by rotating the device;

- The game has an interface menu, where the player can start the game, see the instructions, and quit;

- The game has a pause menu, where the player can resume the game, restart it, or quit;

- The player can choose from three different difficulty levels that define the number of enemies spawned and their spawn speed. The player is prompted to choose the difficulty everytime they start a new game.

- When a game ends, a new sceen is shown, indicating the win or loss of the player, wheter if the winning condition is verified or not.
