CREATE OR REPLACE FUNCTION public.getinactivatecardbyid(
	"paramId" bigint)
    RETURNS TABLE("IdentifierCardId" bigint, "AccountId" bigint, "IdentifierCard" character varying, "Pin" character varying, "Salt" character varying, "ReasonCode" smallint, "Status" smallint, "Attempts" integer, "CreationDate" timestamp without time zone, "UpdateDate" timestamp without time zone, "DeletionDate" timestamp without time zone, "CreationUserId" bigint, "UpdateUserId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
SELECT  "InactivateCardId",
		"AccountId",
	    "IdentifierCard", 
		"Pin", 
		"Salt",
		"ReasonCode", 
		"Status", 
		"Attempts", 
		"CreationDate", 
		"UpdateDate", 
		"DeletionDate", 
		"CreationUserId",
		"UpdateUserId"
	FROM 
		public."InactivateCard"
	WHERE 	
		"InactivateCardId" = "paramId"
	AND
		"DeletionDate" IS NULL
$BODY$;

ALTER FUNCTION public.getinactivatecardbyid(bigint)
    OWNER TO "OSB";
