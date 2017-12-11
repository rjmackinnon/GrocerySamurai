--DROPDATABASE grocery;

DO
$do$
BEGIN
	IF EXISTS	(
                    SELECT	1
                    FROM	information_schema.tables
                    WHERE	table_name = 'app_user'
                    ) THEN
		DROP TABLE app_user
		;
    END IF;


	IF EXISTS	(
                    SELECT	1
                    FROM	information_schema.tables
                    WHERE	table_name = 'grocery_list_item'
                    ) THEN
        DROP TABLE grocery_list_item
        ;
    END IF;


	IF EXISTS	(
                    SELECT	1
                    FROM	information_schema.tables
                    WHERE	table_name = 'store_item'
                    ) THEN
        DROP TABLE store_item
        ;
    END IF;

	IF EXISTS	(
                    SELECT	1
                    FROM	information_schema.tables
                    WHERE	table_name = 'grocery_list'
                    ) THEN
        DROP TABLE grocery_list
        ;
    END IF;


    IF EXISTS	(
                    SELECT	1
                    FROM	information_schema.tables
                    WHERE	table_name = 'store'
                    ) THEN
        DROP TABLE store
        ;
    END IF;


	IF EXISTS	(
                    SELECT	1
                    FROM	information_schema.tables
                    WHERE	table_name = 'aisle'
                    ) THEN
        DROP TABLE aisle
        ;
    END IF;


    IF EXISTS	(
                    SELECT	1
                    FROM	information_schema.tables
                    WHERE	table_name = 'item'
                    ) THEN
        DROP TABLE item
        ;
    END IF;

    DROP FUNCTION clear_test()
	;
END
$do$

