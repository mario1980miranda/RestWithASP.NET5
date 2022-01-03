CREATE TABLE IF NOT EXISTS `person` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `first_name` varchar(80) COLLATE utf8_bin NOT NULL,
  `last_name` varchar(80) COLLATE utf8_bin NOT NULL,
  `address` varchar(100) COLLATE utf8_bin NOT NULL,
  `gender` varchar(6) COLLATE utf8_bin NOT NULL,
  PRIMARY KEY (`id`)
)