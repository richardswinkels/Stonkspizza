-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Gegenereerd op: 06 apr 2022 om 20:05
-- Serverversie: 5.7.36
-- PHP-versie: 8.0.13

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `project4`
--

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `bikebrands`
--

DROP TABLE IF EXISTS `bikebrands`;
CREATE TABLE IF NOT EXISTS `bikebrands` (
  `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT,
  `name` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci ROW_FORMAT=DYNAMIC;

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `bikemodels`
--

DROP TABLE IF EXISTS `bikemodels`;
CREATE TABLE IF NOT EXISTS `bikemodels` (
  `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT,
  `name` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci ROW_FORMAT=DYNAMIC;

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `bikes`
--

DROP TABLE IF EXISTS `bikes`;
CREATE TABLE IF NOT EXISTS `bikes` (
  `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT,
  `brand_id` bigint(20) UNSIGNED NOT NULL,
  `model_id` bigint(20) UNSIGNED NOT NULL,
  `employee_id` bigint(20) UNSIGNED NOT NULL,
  PRIMARY KEY (`id`),
  KEY `bikes_brand_id_foreign` (`brand_id`),
  KEY `bikes_model_id_foreign` (`model_id`),
  KEY `bikes_employee_id_foreign` (`employee_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci ROW_FORMAT=DYNAMIC;

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `customers`
--

DROP TABLE IF EXISTS `customers`;
CREATE TABLE IF NOT EXISTS `customers` (
  `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT,
  `first_name` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `last_name` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `address` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `phone` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `zipcode` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `city` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `pizza_points` int(11) NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci ROW_FORMAT=DYNAMIC;

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `employees`
--

DROP TABLE IF EXISTS `employees`;
CREATE TABLE IF NOT EXISTS `employees` (
  `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT,
  `first_name` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `last_name` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `address` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `phone` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `zipcode` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `city` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `country` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `personal_email` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `birth_date` date DEFAULT NULL,
  `burger_service_nummer` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci ROW_FORMAT=DYNAMIC;

--
-- Gegevens worden geëxporteerd voor tabel `employees`
--

INSERT INTO `employees` (`id`, `first_name`, `last_name`, `address`, `phone`, `zipcode`, `city`, `country`, `personal_email`, `birth_date`, `burger_service_nummer`, `created_at`, `updated_at`) VALUES
(1, 'samira', 'achternaam', 'straatnaam 1', '06123456789', '1111AB', 'Eindhoven', NULL, 'user@domein.nl', '2022-01-01', '11111111111', '2022-04-06 20:04:56', '2022-04-06 20:04:56'),
(2, 'peter', 'achternaam', 'straatnaam 1', '06123456789', '1111AB', 'Eindhoven', NULL, 'user@domein.nl', '2022-01-01', '11111111111', '2022-04-06 20:04:56', '2022-04-06 20:04:56'),
(3, 'mohammed', 'achternaam', 'straatnaam 1', '06123456789', '1111AB', 'Eindhoven', NULL, 'user@domein.nl', '2022-01-01', '11111111111', '2022-04-06 20:04:56', '2022-04-06 20:04:56'),
(4, 'ginny', 'achternaam', 'straatnaam 1', '06123456789', '1111AB', 'Eindhoven', NULL, 'user@domein.nl', '2022-01-01', '11111111111', '2022-04-06 20:04:56', '2022-04-06 20:04:56'),
(5, 'michelle', 'achternaam', 'straatnaam 1', '06123456789', '1111AB', 'Eindhoven', NULL, 'user@domein.nl', '2022-01-01', '11111111111', '2022-04-06 20:04:56', '2022-04-06 20:04:56'),
(6, 'Hamza', 'Al-Hussein', 'straatnaam 1', '06123456789', '1111AB', 'Eindhoven', NULL, 'user@domein.nl', '2022-01-01', '11111111111', '2022-04-06 20:04:56', '2022-04-06 20:04:56'),
(7, 'Koen', 'van der Velden', 'straatnaam 1', '06123456789', '1111AB', 'Eindhoven', NULL, 'user@domein.nl', '2022-01-01', '11111111111', '2022-04-06 20:04:56', '2022-04-06 20:04:56');

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `failed_jobs`
--

DROP TABLE IF EXISTS `failed_jobs`;
CREATE TABLE IF NOT EXISTS `failed_jobs` (
  `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT,
  `uuid` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `connection` text COLLATE utf8mb4_unicode_ci NOT NULL,
  `queue` text COLLATE utf8mb4_unicode_ci NOT NULL,
  `payload` longtext COLLATE utf8mb4_unicode_ci NOT NULL,
  `exception` longtext COLLATE utf8mb4_unicode_ci NOT NULL,
  `failed_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  UNIQUE KEY `failed_jobs_uuid_unique` (`uuid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci ROW_FORMAT=DYNAMIC;

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `ingredients`
--

DROP TABLE IF EXISTS `ingredients`;
CREATE TABLE IF NOT EXISTS `ingredients` (
  `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT,
  `name` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `price` double(4,2) NOT NULL,
  `quantity` bigint(20) NOT NULL,
  `unit_id` bigint(20) UNSIGNED NOT NULL,
  PRIMARY KEY (`id`),
  KEY `ingredients_unit_id_foreign` (`unit_id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci ROW_FORMAT=DYNAMIC;

--
-- Gegevens worden geëxporteerd voor tabel `ingredients`
--

INSERT INTO `ingredients` (`id`, `name`, `price`, `quantity`, `unit_id`) VALUES
(1, 'Bodemdeeg', 0.50, 100, 1),
(2, 'Mozerella', 2.50, 100, 1),
(3, 'Saus', 0.25, 100, 3),
(4, 'Ui', 0.50, 100, 2),
(5, 'Tomaat', 0.80, 100, 2),
(6, 'Kaas', 0.40, 100, 1),
(7, 'Ananas', 0.90, 100, 1),
(8, 'Ham', 1.20, 100, 1);

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `ingredient_orderitem`
--

DROP TABLE IF EXISTS `ingredient_orderitem`;
CREATE TABLE IF NOT EXISTS `ingredient_orderitem` (
  `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT,
  `orderitem_id` bigint(20) UNSIGNED DEFAULT NULL,
  `ingredient_id` bigint(20) UNSIGNED DEFAULT NULL,
  `quantity` bigint(20) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`),
  KEY `ingredient_orderitem_orderitem_id_foreign` (`orderitem_id`),
  KEY `ingredient_orderitem_ingredient_id_foreign` (`ingredient_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci ROW_FORMAT=DYNAMIC;

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `ingredient_pizza`
--

DROP TABLE IF EXISTS `ingredient_pizza`;
CREATE TABLE IF NOT EXISTS `ingredient_pizza` (
  `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT,
  `pizza_id` bigint(20) UNSIGNED NOT NULL,
  `ingredient_id` bigint(20) UNSIGNED NOT NULL,
  `quantity` bigint(20) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`),
  KEY `ingredient_pizza_pizza_id_foreign` (`pizza_id`),
  KEY `ingredient_pizza_ingredient_id_foreign` (`ingredient_id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci ROW_FORMAT=DYNAMIC;

--
-- Gegevens worden geëxporteerd voor tabel `ingredient_pizza`
--

INSERT INTO `ingredient_pizza` (`id`, `pizza_id`, `ingredient_id`, `quantity`) VALUES
(1, 1, 1, 1),
(2, 1, 2, 1),
(3, 1, 3, 1),
(4, 1, 4, 1),
(5, 2, 1, 1),
(6, 2, 3, 1),
(7, 2, 6, 1),
(8, 2, 7, 1),
(9, 2, 8, 1),
(10, 3, 1, 1),
(11, 3, 4, 1),
(12, 3, 5, 1),
(13, 3, 8, 1);

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `migrations`
--

DROP TABLE IF EXISTS `migrations`;
CREATE TABLE IF NOT EXISTS `migrations` (
  `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `migration` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `batch` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci ROW_FORMAT=DYNAMIC;

--
-- Gegevens worden geëxporteerd voor tabel `migrations`
--

INSERT INTO `migrations` (`id`, `migration`, `batch`) VALUES
(1, '2014_10_12_000000_create_users_table', 1),
(2, '2014_10_12_100000_create_password_resets_table', 1),
(3, '2019_08_19_000000_create_failed_jobs_table', 1),
(4, '2019_12_14_000001_create_personal_access_tokens_table', 1),
(5, '2021_12_13_210500_create_roles_table', 1),
(6, '2021_12_13_210525_create_user_roles_table', 1),
(7, '2021_12_23_081833_create_customers_table', 1),
(8, '2021_12_23_092020_create_employees_table', 1),
(9, '2022_01_11_083814_create_sizes_table', 1),
(10, '2022_01_12_080059_create_units_table', 1),
(11, '2022_01_12_083318_create_pizzas_table', 1),
(12, '2022_01_12_091047_create_ingredients_table', 1),
(13, '2022_01_12_091233_create_ingredient_pizza_table', 1),
(14, '2022_01_19_114959_create_status_table', 1),
(15, '2022_01_19_120229_create_orders_table', 1),
(16, '2022_01_19_120832_create_order_pizza_table', 1),
(17, '2022_01_19_123956_create_ordertransactions_table', 1),
(18, '2022_01_19_124710_create_bikebrands_table', 1),
(19, '2022_01_19_124722_create_bikemodels_table', 1),
(20, '2022_01_19_124729_create_bikes_table', 1),
(21, '2022_01_20_151341_create_orderitems_table', 1),
(22, '2022_01_20_151552_create_ingredient_orderitem_table', 1);

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `orderitems`
--

DROP TABLE IF EXISTS `orderitems`;
CREATE TABLE IF NOT EXISTS `orderitems` (
  `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT,
  `pizza_id` bigint(20) UNSIGNED NOT NULL,
  `size_id` bigint(20) UNSIGNED NOT NULL,
  `order_id` bigint(20) UNSIGNED DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `orderitems_pizza_id_foreign` (`pizza_id`),
  KEY `orderitems_size_id_foreign` (`size_id`),
  KEY `orderitems_order_id_foreign` (`order_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci ROW_FORMAT=DYNAMIC;

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `orders`
--

DROP TABLE IF EXISTS `orders`;
CREATE TABLE IF NOT EXISTS `orders` (
  `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT,
  `deliverytime` timestamp NOT NULL,
  `customer_id` bigint(20) UNSIGNED NOT NULL,
  `status_id` bigint(20) UNSIGNED NOT NULL DEFAULT '1',
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `orders_customer_id_foreign` (`customer_id`),
  KEY `orders_status_id_foreign` (`status_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci ROW_FORMAT=DYNAMIC;

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `ordertransactions`
--

DROP TABLE IF EXISTS `ordertransactions`;
CREATE TABLE IF NOT EXISTS `ordertransactions` (
  `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT,
  `order_id` bigint(20) UNSIGNED NOT NULL,
  `user_id` bigint(20) UNSIGNED NOT NULL,
  `to_status_id` bigint(20) UNSIGNED NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `ordertransactions_order_id_foreign` (`order_id`),
  KEY `ordertransactions_user_id_foreign` (`user_id`),
  KEY `ordertransactions_to_status_id_foreign` (`to_status_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci ROW_FORMAT=DYNAMIC;

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `order_pizza`
--

DROP TABLE IF EXISTS `order_pizza`;
CREATE TABLE IF NOT EXISTS `order_pizza` (
  `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT,
  `pizza_id` bigint(20) UNSIGNED NOT NULL,
  `order_id` bigint(20) UNSIGNED NOT NULL,
  PRIMARY KEY (`id`),
  KEY `order_pizza_pizza_id_foreign` (`pizza_id`),
  KEY `order_pizza_order_id_foreign` (`order_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci ROW_FORMAT=DYNAMIC;

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `password_resets`
--

DROP TABLE IF EXISTS `password_resets`;
CREATE TABLE IF NOT EXISTS `password_resets` (
  `email` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `token` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  KEY `password_resets_email_index` (`email`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci ROW_FORMAT=DYNAMIC;

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `personal_access_tokens`
--

DROP TABLE IF EXISTS `personal_access_tokens`;
CREATE TABLE IF NOT EXISTS `personal_access_tokens` (
  `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT,
  `tokenable_type` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `tokenable_id` bigint(20) UNSIGNED NOT NULL,
  `name` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `token` varchar(64) COLLATE utf8mb4_unicode_ci NOT NULL,
  `abilities` text COLLATE utf8mb4_unicode_ci,
  `last_used_at` timestamp NULL DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `personal_access_tokens_token_unique` (`token`),
  KEY `personal_access_tokens_tokenable_type_tokenable_id_index` (`tokenable_type`,`tokenable_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci ROW_FORMAT=DYNAMIC;

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `pizzas`
--

DROP TABLE IF EXISTS `pizzas`;
CREATE TABLE IF NOT EXISTS `pizzas` (
  `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT,
  `name` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `is_custom` tinyint(1) NOT NULL,
  `user_id` bigint(20) UNSIGNED DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `pizzas_user_id_foreign` (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci ROW_FORMAT=DYNAMIC;

--
-- Gegevens worden geëxporteerd voor tabel `pizzas`
--

INSERT INTO `pizzas` (`id`, `name`, `is_custom`, `user_id`) VALUES
(1, 'Mozerella', 0, NULL),
(2, 'Hawaii', 0, NULL),
(3, 'Margerita', 0, NULL);

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `roles`
--

DROP TABLE IF EXISTS `roles`;
CREATE TABLE IF NOT EXISTS `roles` (
  `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT,
  `name` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=1000 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci ROW_FORMAT=DYNAMIC;

--
-- Gegevens worden geëxporteerd voor tabel `roles`
--

INSERT INTO `roles` (`id`, `name`, `created_at`, `updated_at`) VALUES
(1, 'klant', '2022-04-06 20:04:56', '2022-04-06 20:04:56'),
(2, 'balie', '2022-04-06 20:04:56', '2022-04-06 20:04:56'),
(3, 'bereiding', '2022-04-06 20:04:56', '2022-04-06 20:04:56'),
(4, 'bezorging', '2022-04-06 20:04:56', '2022-04-06 20:04:56'),
(5, 'management', '2022-04-06 20:04:56', '2022-04-06 20:04:56'),
(999, 'admin', '2022-04-06 20:04:56', '2022-04-06 20:04:56');

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `sizes`
--

DROP TABLE IF EXISTS `sizes`;
CREATE TABLE IF NOT EXISTS `sizes` (
  `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT,
  `name` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `pricefactor` double(8,2) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci ROW_FORMAT=DYNAMIC;

--
-- Gegevens worden geëxporteerd voor tabel `sizes`
--

INSERT INTO `sizes` (`id`, `name`, `pricefactor`) VALUES
(1, 'Klein', 0.80),
(2, 'Middel', 1.00),
(3, 'Groot', 1.20);

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `statuses`
--

DROP TABLE IF EXISTS `statuses`;
CREATE TABLE IF NOT EXISTS `statuses` (
  `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT,
  `name` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci ROW_FORMAT=DYNAMIC;

--
-- Gegevens worden geëxporteerd voor tabel `statuses`
--

INSERT INTO `statuses` (`id`, `name`) VALUES
(1, 'Besteld'),
(2, 'Wordt bereid'),
(3, 'In de oven'),
(4, 'Onderweg'),
(5, 'Bezorgd'),
(6, 'Geannuleerd');

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `units`
--

DROP TABLE IF EXISTS `units`;
CREATE TABLE IF NOT EXISTS `units` (
  `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT,
  `name` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci ROW_FORMAT=DYNAMIC;

--
-- Gegevens worden geëxporteerd voor tabel `units`
--

INSERT INTO `units` (`id`, `name`) VALUES
(1, '100gr'),
(2, '1 stuk'),
(3, '100ml');

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `users`
--

DROP TABLE IF EXISTS `users`;
CREATE TABLE IF NOT EXISTS `users` (
  `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT,
  `name` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `email` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `email_verified_at` timestamp NULL DEFAULT NULL,
  `password` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `remember_token` varchar(100) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `users_email_unique` (`email`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci ROW_FORMAT=DYNAMIC;

--
-- Gegevens worden geëxporteerd voor tabel `users`
--

INSERT INTO `users` (`id`, `name`, `email`, `email_verified_at`, `password`, `remember_token`, `created_at`, `updated_at`) VALUES
(1, 'samira', 'samira@pizzasumma.nl', NULL, '$2y$10$T17Qacstw7TRghD3NSndD.QnMt5aoHtEzoNFEdjOi8QQfA8aQrr2W', NULL, '2022-04-06 20:04:55', '2022-04-06 20:04:55'),
(2, 'peter', 'peter@pizzasumma.nl', NULL, '$2y$10$gLCjsxu9dokxssA0mbC6suy3mgF7OQ/E7oxcoypwIvB3MaGpXzPOi', NULL, '2022-04-06 20:04:55', '2022-04-06 20:04:55'),
(3, 'mohammed', 'mohammed@pizzasumma.nl', NULL, '$2y$10$KZ0SXJkp5QPONIge1Meu2Od2QaznbCgELqrc7DEDSJU/Nsm2NEUpO', NULL, '2022-04-06 20:04:55', '2022-04-06 20:04:55'),
(4, 'ginny', 'ginny@pizzasumma.nl', NULL, '$2y$10$yPCTKfykzs38mS76Um2ALu9vxKTKNdGH0DPAVRmn7EMoifhxH4HgK', NULL, '2022-04-06 20:04:55', '2022-04-06 20:04:55'),
(5, 'michelle', 'michelle@pizzasumma.nl', NULL, '$2y$10$YKrDYDVSDjqxzEfanJQRZ.YFRb1Z0So85vNJFUODzOdvaOU5Ox7RK', NULL, '2022-04-06 20:04:55', '2022-04-06 20:04:55'),
(6, 'Hamza Al-Hussein', 'hah@test.test', NULL, '$2y$10$gMv.iS9zec5Vgh5XTOgLpuSvSDxbdVzn22leua5t9oUSjEdmJUWrO', NULL, '2022-04-06 20:04:55', '2022-04-06 20:04:55'),
(7, 'Koen van der Velden', 'kvv@test.test', NULL, '$2y$10$jvGdmWIayJDm03pezVLjAezBQad/WzxJ6EKEjYHtjscpbaiVfLIB.', NULL, '2022-04-06 20:04:55', '2022-04-06 20:04:55'),
(8, 'Ilse Gijsbrechts', 'ig@test.test', NULL, '$2y$10$c5eiBcY93SOgiG2BuZ2QX.iZjEudl.cVle58z210b/th.BEktX6sW', NULL, '2022-04-06 20:04:56', '2022-04-06 20:04:56');

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `user_roles`
--

DROP TABLE IF EXISTS `user_roles`;
CREATE TABLE IF NOT EXISTS `user_roles` (
  `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT,
  `user_id` int(11) NOT NULL,
  `role_id` int(11) NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci ROW_FORMAT=DYNAMIC;

--
-- Gegevens worden geëxporteerd voor tabel `user_roles`
--

INSERT INTO `user_roles` (`id`, `user_id`, `role_id`, `created_at`, `updated_at`) VALUES
(1, 1, 999, NULL, NULL),
(2, 2, 2, NULL, NULL),
(3, 3, 3, NULL, NULL),
(4, 4, 4, NULL, NULL),
(5, 5, 5, NULL, NULL),
(6, 6, 1, NULL, NULL),
(7, 7, 1, NULL, NULL),
(8, 8, 1, NULL, NULL);

--
-- Beperkingen voor geëxporteerde tabellen
--

--
-- Beperkingen voor tabel `bikes`
--
ALTER TABLE `bikes`
  ADD CONSTRAINT `bikes_brand_id_foreign` FOREIGN KEY (`brand_id`) REFERENCES `bikebrands` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `bikes_employee_id_foreign` FOREIGN KEY (`employee_id`) REFERENCES `employees` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `bikes_model_id_foreign` FOREIGN KEY (`model_id`) REFERENCES `bikemodels` (`id`) ON DELETE CASCADE;

--
-- Beperkingen voor tabel `ingredients`
--
ALTER TABLE `ingredients`
  ADD CONSTRAINT `ingredients_unit_id_foreign` FOREIGN KEY (`unit_id`) REFERENCES `units` (`id`) ON DELETE CASCADE;

--
-- Beperkingen voor tabel `ingredient_orderitem`
--
ALTER TABLE `ingredient_orderitem`
  ADD CONSTRAINT `ingredient_orderitem_ingredient_id_foreign` FOREIGN KEY (`ingredient_id`) REFERENCES `ingredients` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `ingredient_orderitem_orderitem_id_foreign` FOREIGN KEY (`orderitem_id`) REFERENCES `orderitems` (`id`) ON DELETE CASCADE;

--
-- Beperkingen voor tabel `ingredient_pizza`
--
ALTER TABLE `ingredient_pizza`
  ADD CONSTRAINT `ingredient_pizza_ingredient_id_foreign` FOREIGN KEY (`ingredient_id`) REFERENCES `ingredients` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `ingredient_pizza_pizza_id_foreign` FOREIGN KEY (`pizza_id`) REFERENCES `pizzas` (`id`) ON DELETE CASCADE;

--
-- Beperkingen voor tabel `orderitems`
--
ALTER TABLE `orderitems`
  ADD CONSTRAINT `orderitems_order_id_foreign` FOREIGN KEY (`order_id`) REFERENCES `orders` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `orderitems_pizza_id_foreign` FOREIGN KEY (`pizza_id`) REFERENCES `pizzas` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `orderitems_size_id_foreign` FOREIGN KEY (`size_id`) REFERENCES `sizes` (`id`) ON DELETE CASCADE;

--
-- Beperkingen voor tabel `orders`
--
ALTER TABLE `orders`
  ADD CONSTRAINT `orders_customer_id_foreign` FOREIGN KEY (`customer_id`) REFERENCES `customers` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `orders_status_id_foreign` FOREIGN KEY (`status_id`) REFERENCES `statuses` (`id`) ON DELETE CASCADE;

--
-- Beperkingen voor tabel `ordertransactions`
--
ALTER TABLE `ordertransactions`
  ADD CONSTRAINT `ordertransactions_order_id_foreign` FOREIGN KEY (`order_id`) REFERENCES `orders` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `ordertransactions_to_status_id_foreign` FOREIGN KEY (`to_status_id`) REFERENCES `statuses` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `ordertransactions_user_id_foreign` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`) ON DELETE CASCADE;

--
-- Beperkingen voor tabel `order_pizza`
--
ALTER TABLE `order_pizza`
  ADD CONSTRAINT `order_pizza_order_id_foreign` FOREIGN KEY (`order_id`) REFERENCES `orders` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `order_pizza_pizza_id_foreign` FOREIGN KEY (`pizza_id`) REFERENCES `pizzas` (`id`) ON DELETE CASCADE;

--
-- Beperkingen voor tabel `pizzas`
--
ALTER TABLE `pizzas`
  ADD CONSTRAINT `pizzas_user_id_foreign` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
