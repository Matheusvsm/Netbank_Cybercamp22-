DROP FUNCTION public.getactivatecardbystatus(integer);

CREATE OR REPLACE FUNCTION public.getactivatecardbystatus(
	"paramStatus" integer)
    RETURNS TABLE("ActivateCardId" bigint, "AccountId" bigint, "OperationId" bigint, "IdentifierCard" character varying, "Status" integer, "CreationDate" timestamp without time zone, "UpdateDate" timestamp without time zone, "DeletionDate" timestamp without time zone, "CreationUserId" bigint, "UpdateUserId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
SELECT "ActivateCardId",
		"AccountId",
        "OperationId",
        "IdentifierCard",
        "Status",        
        "CreationDate",
        "UpdateDate",
        "DeletionDate",
        "CreationUserId",
        "UpdateUserId"

FROM public."ActivateCard"
WHERE 
	"Status" = "paramStatus"
	AND "DeletionDate" IS NULL;
$BODY$;

ALTER FUNCTION public.getactivatecardbystatus(integer)
    OWNER TO "OSB";