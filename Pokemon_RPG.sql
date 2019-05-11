CREATE TABLE `user`
(
  `id` int PRIMARY KEY,
  `full_name` varchar(255),
  `email` varchar(255) UNIQUE,
  `gender` varchar(255),
  `date_of_birth` varchar(255),
  `created_at` varchar(255)
);

CREATE TABLE `player`
(
  `id` int UNIQUE PRIMARY KEY NOT NULL,
  `user_id` int,
  `name` varchar(255),
  `exp` int,
  `level` int,
  `maxHealth` int,
  `currentHealth` int,
  `created_at` varchar(255) 
);

CREATE TABLE `playerPokedex`
(
  `id` int PRIMARY KEY,
  `playerInt` int
);

CREATE TABLE `playerPokedexEntry`
(
  `id` int PRIMARY KEY,
  `playerPokedexId` int,
  `breedId` int,
  `seen` bool,
  `owned` bool
);

CREATE TABLE `diary`
(
  `id` int PRIMARY KEY,
  `player_id` int,
  `date` datetime,
  `entry` varchar(255)
);

CREATE TABLE `pokemon`
(
  `id` int PRIMARY KEY,
  `player_id` int,
  `breed_id` int,
  `nickname` varchar(255),
  `sex` varchar(255),
  `exp` int,
  `level` int,
  `dietId` int,
  `attitudeId` int,
  `caughtOn` datetime,
  `pokeballTypeId` int
);

CREATE TABLE `pokeballType`
(
    `id` int PRIMARY KEY NOT NULL,
    `name` varchar(255) NOT NULL
)

CREATE TABLE `inventory`
(
  `id` int PRIMARY KEY,
  `playerId` int
);

CREATE TABLE `inventoryEntry`
(
  `id` int,
  `inventoryId` int,
  `itemId` int
);

CREATE TABLE `item`
(
  `id` int,
  `name` varchar(255),
  `effectTypeId` int
);

CREATE TABLE `effect`
(
  `id` int,
  `name` varchar(255)
);

CREATE TABLE `pokemonBreed`
(
  `id` int PRIMARY KEY,
  `name` varchar(255),
  `sex` varchar(255) NOT NULL,
  `price` int,
  `status` varchar(255),
  `created_at` varchar(255),
  `pokedexId` int
);

CREATE TABLE `pokedex`
(
  `id` int PRIMARY KEY,
  `evolvesFromBreedId` int,
  `entry` varchar(255),
  `generation` int,
  `evolvesAtExp` int,
  `imageLocation` varchar(255),
  `type1Id` int,
  `type2Id` int
);

CREATE TABLE `diet`
(
  `id` int,
  `name` varchar(255),
  `description` varchar(255)
);

CREATE TABLE `attitude`
(
  `id` int,
  `name` varchar(255),
  `description` varchar(255)
);

ALTER TABLE `player` ADD FOREIGN KEY (`user_id`) REFERENCES `user` (`id`);

ALTER TABLE `playerPokedex` ADD FOREIGN KEY (`playerInt`) REFERENCES `player` (`id`);

ALTER TABLE `playerPokedex` ADD FOREIGN KEY (`pokemonBreedId`) REFERENCES `pokemonBreed` (`id`);

ALTER TABLE `playerPokedexEntry` ADD FOREIGN KEY (`playerPokedexId`) REFERENCES `playerPokedex` (`id`);

ALTER TABLE `diary` ADD FOREIGN KEY (`player_id`) REFERENCES `player` (`id`);

ALTER TABLE `pokemon` ADD FOREIGN KEY (`player_id`) REFERENCES `player` (`id`);

ALTER TABLE `pokemon` ADD FOREIGN KEY (`dietId`) REFERENCES `diet` (`id`);

ALTER TABLE `pokemon` ADD FOREIGN KEY (`attitudeId`) REFERENCES `attitude` (`id`);

ALTER TABLE `inventory` ADD FOREIGN KEY (`playerId`) REFERENCES `player` (`id`);

ALTER TABLE `inventoryEntry` ADD FOREIGN KEY (`inventoryId`) REFERENCES `inventory` (`id`);

ALTER TABLE `inventoryEntry` ADD FOREIGN KEY (`itemId`) REFERENCES `item` (`id`);

ALTER TABLE `item` ADD FOREIGN KEY (`effectTypeId`) REFERENCES `effect` (`id`);

ALTER TABLE `pokemon` ADD FOREIGN KEY (`breed_id`) REFERENCES `pokemonBreed` (`id`);

ALTER TABLE `pokemonBreed` ADD FOREIGN KEY (`pokedexId`) REFERENCES `pokedex` (`id`);
