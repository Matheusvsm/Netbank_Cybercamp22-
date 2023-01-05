DROP FUNCTION public.getinactivatecardbystatus(integer);

CREATE OR REPLACE FUNCTION public.getinactivatecardbystatus(
	"paramStatus" integer)
    RETURNS TABLE("InactivateCardId" bigint, "AccountId" bigint, "OperationId" bigint, "IdentifierCard" character varying, "Pin" character varying, "Salt" character varying, "ReasonCode" integer, "Status" integer, "CreationDate" timestamp without time zone, "UpdateDate" timestamp without time zone, "DeletionDate" timestamp without time zone, "CreationUserId" bigint, "UpdateUserId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
SELECT  "InactivateCardId",
		"AccountId",
		"OperationId",
	    "IdentifierCard", 
		"Pin", 
		"Salt",
		"ReasonCode", 
		"Status", 		
		"CreationDate", 
		"UpdateDate", 
		"DeletionDate", 
		"CreationUserId",
		"UpdateUserId"
	FROM 
		public."InactivateCard"
	WHERE 	
		"Status" = "paramStatus"
	AND
		"DeletionDate" IS NULL		
$BODY$;

ALTER FUNCTION public.getinactivatecardbystatus(integer)
    OWNER TO "OSB";
