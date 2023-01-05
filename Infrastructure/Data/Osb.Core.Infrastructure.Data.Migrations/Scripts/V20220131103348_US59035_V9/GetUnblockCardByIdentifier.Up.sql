DROP FUNCTION public.getunblockcardbyidentifier(character varying);

CREATE OR REPLACE FUNCTION public.getunblockcardbyidentifier(
	"paramIdentifier" character varying)
    RETURNS TABLE(
		"UnblockCardId" bigint, 
		"IdentifierCard" character varying,
		"Pin" character varying, 
		"Salt" character varying, 
		"AccountId" bigint,		
		"Status" integer,
		"OperationId" bigint,
		"CreationDate" timestamp without time zone,
		"DeletionDate" timestamp without time zone,
		"UpdateDate" timestamp without time zone,
		"CreationUserId" bigint, 
		"UpdateUserId" bigint
		)
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
        "IdentifierCard" = "paramIdentifier"
        AND "DeletionDate" IS NULL
$BODY$;

ALTER FUNCTION public.getunblockcardbyidentifier(character varying)
    OWNER TO "OSB";