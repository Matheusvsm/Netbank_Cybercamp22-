CREATE OR REPLACE FUNCTION public.getoperationtagsbyoperationid(
	"paramOperationId" bigint
    )
    RETURNS TABLE( 
        "OperationTagId" bigint,
        "OperationId" bigint,
        "Tag" character varying, 
        "CreationDate"  timestamp without time zone, 
        "UpdateDate"  timestamp without time zone, 
        "DeletionDate"  timestamp without time zone, 
        "CreationUserId" bigint, 
        "UpdateUserId" bigint
    )
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
SELECT 
        "OperationTagId",
        "OperationId",
        "Tag",
        "CreationDate", 
		"UpdateDate",
		"DeletionDate", 
		"CreationUserId", 
		"UpdateUserId"
    FROM
        public."OperationTag"
    WHERE 
        "OperationId" = "paramOperationId"
    AND
        "DeletionDate" IS NULL
$BODY$;

ALTER FUNCTION public.getoperationtagsbyoperationid(bigint)
    OWNER TO "OSB";