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
        ALTER TABLE item ADD CONSTRAINT uq_item_name UNIQUE (name);

        ALTER TABLE item ADD CONSTRAINT uq_item_upc UNIQUE (upc);
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
		ALTER TABLE store ADD CONSTRAINT uq_store_name UNIQUE (name);
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
        ALTER TABLE aisle ADD CONSTRAINT uq_aisle_name UNIQUE (name);
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
        ALTER TABLE store_item ADD CONSTRAINT uq_store_item UNIQUE (store_id, aisle_id, item_id);
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
        ALTER TABLE grocery_list ADD CONSTRAINT uq_grocery_list UNIQUE (name);
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
        ALTER TABLE grocery_list_item ADD CONSTRAINT uq_grocery_list_item UNIQUE (grocery_list_id, item_id);
    END IF;

	IF NOT EXISTS	(
                    SELECT	1
                    FROM	information_schema.tables
                    WHERE	table_name = 'app_user'
                    ) THEN
		CREATE TABLE app_user
			(
		     id					SERIAL					PRIMARY KEY	
			,username			VARCHAR(45) NOT NULL
		    ,password			VARCHAR(45)
		    ,firstname			VARCHAR(45) NOT NULL
		    ,lastname			VARCHAR(45)
		    ,email				VARCHAR(45)
		    ,address			VARCHAR(45)
		    ,phone				INT
			)
		;
        ALTER TABLE app_user ADD CONSTRAINT uq_app_user_username UNIQUE (username);

        ALTER TABLE app_user ADD CONSTRAINT uq_app_user_email UNIQUE (email);
    END IF;

    CREATE OR REPLACE FUNCTION clear_test()
    RETURNS integer AS $$
    BEGIN
        TRUNCATE TABLE aisle CASCADE;
        TRUNCATE TABLE store CASCADE;
        TRUNCATE TABLE item CASCADE;

        RETURN 1;
    END;
	$$ LANGUAGE plpgsql;
END
$do$
