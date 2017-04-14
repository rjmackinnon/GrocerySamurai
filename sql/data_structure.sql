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
             id					SERIAL					PRIMARY KEY
            ,name				VARCHAR(255) NOT NULL
            ,description		VARCHAR(1000)
            ,upc				BIGINT
        )
        ;
    END IF;

    IF NOT EXISTS	(
                    SELECT	1
                    FROM	information_schema.tables
                    WHERE	table_name = 'store'
                    ) THEN
        CREATE TABLE store
        (
             id					SERIAL					PRIMARY KEY
            ,name				VARCHAR(255) NOT NULL
            ,description		VARCHAR(1000)
        )
        ;
    END IF;

	IF NOT EXISTS	(
                    SELECT	1
                    FROM	information_schema.tables
                    WHERE	table_name = 'aisle'
                    ) THEN
        CREATE TABLE aisle
        (
             id					SERIAL					PRIMARY KEY
            ,name				VARCHAR(255) NOT NULL
            ,description		VARCHAR(1000)
        )
        ;
    END IF;

	IF NOT EXISTS	(
                    SELECT	1
                    FROM	information_schema.tables
                    WHERE	table_name = 'store_item'
                    ) THEN
        CREATE TABLE store_item
        (
             id					SERIAL					PRIMARY KEY
            ,store_id			INT NOT NULL 			REFERENCES store(id)
            ,aisle_id			INT NOT NULL			REFERENCES aisle(id)
            ,item_id			INT NOT NULL			REFERENCES item(id)
        )
        ;
    END IF;

	IF NOT EXISTS	(
                    SELECT	1
                    FROM	information_schema.tables
                    WHERE	table_name = 'grocery_list'
                    ) THEN
        CREATE TABLE grocery_list
        (
             id					SERIAL					PRIMARY KEY
            ,store_id			INT NOT NULL 			REFERENCES store(id)
            ,name				VARCHAR(255) NOT NULL
            ,description		VARCHAR(1000)
        )
        ;
    END IF;

	IF NOT EXISTS	(
                    SELECT	1
                    FROM	information_schema.tables
                    WHERE	table_name = 'grocery_list_item'
                    ) THEN
        CREATE TABLE grocery_list_item
        (
             id					SERIAL					PRIMARY KEY
            ,grocery_list_id	INT NOT NULL 			REFERENCES grocery_list(id)
            ,item_id			INT NOT NULL			REFERENCES item(id)
            ,quantity			INT NOT NULL
            ,package_type		VARCHAR(30)
            ,weight				INT
        )
        ;
    END IF;
END
$do$
