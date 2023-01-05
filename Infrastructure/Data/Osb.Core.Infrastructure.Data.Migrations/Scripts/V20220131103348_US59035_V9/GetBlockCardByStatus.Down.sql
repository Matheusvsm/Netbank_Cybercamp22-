DROP FUNCTION public.getblockcardbystatus(integer);

CREATE OR REPLACE FUNCTION public.getblockcardbystatus(
	"paramStatus" integer)
    RETURNS TABLE("BlockCardId" bigint, "IdentifierCard" character varying, "Pin" character varying, "Salt" character varying, "ReasonCode" integer, "AccountId" bigint, "Attempts" integer, "Status" integer, "OperationId" bigint, "CreationDate" timestamp without time zone, "DeletionDate" timestamp without time zone, "UpdateDate" timestamp without time zone, "CreationUserId" bigint, "UpdateUserId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
SELECT 
        "BlockCardId",
        "IdentifierCard",
        "Pin",
        "Salt",
        "ReasonCode",
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
        public."BlockCard"
WHERE 
        "Status" = "paramStatus"
        AND "DeletionDate" IS NULL
$BODY$;

ALTER FUNCTION public.getblockcardbystatus(integer)
    OWNER TO "OSB";
