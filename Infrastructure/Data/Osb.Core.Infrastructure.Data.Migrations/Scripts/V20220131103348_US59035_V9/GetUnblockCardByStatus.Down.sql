DROP FUNCTION public.getunblockcardbystatus(integer);

CREATE OR REPLACE FUNCTION public.getunblockcardbystatus(
	"paramStatus" integer)
    RETURNS TABLE("UnblockCardId" bigint, "IdentifierCard" character varying, "Pin" character varying, "Salt" character varying, "AccountId" bigint, "Attempts" integer, "Status" integer, "OperationId" bigint, "CreationDate" timestamp without time zone, "DeletionDate" timestamp without time zone, "UpdateDate" timestamp without time zone, "CreationUserId" bigint, "UpdateUserId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
SELECT 
        "UnblockCardId",
        "IdentifierCard",
        "Pin",
        "Salt",        
        "AccountId",
        "Attempts",
        "Status",
        "OperationId",
        "CreationDate",
        "DeletionDate",
        "UpdateDate",
        "CreationUserId",
        "UpdateUserId"
FROM 
        public."UnblockCard"
WHERE 
        "Status" = "paramStatus"
        AND "DeletionDate" IS NULL
$BODY$;

ALTER FUNCTION public.getunblockcardbystatus(integer)
    OWNER TO "OSB";
