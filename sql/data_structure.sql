--CREATE DATABASE grocery;

DO
$do$
BEGIN
    IF NOT EXISTS	(
                    SELECT	1
                    FROM	information_schema.tables
                    WHERE	table_name = 'item'
                    ) THEN
        CREATE TABLE item
        (
             id				SERIAL	PRIMARY KEY
            ,name			VARCHAR(255) NOT NULL
            ,description	VARCHAR(1000)
            ,upc			BIGINT
        )
        ;
    END IF;
END
$do$
