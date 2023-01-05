CREATE OR REPLACE FUNCTION public.getbindcardbyidentifier(
	"paramIdentifier" character varying)
    RETURNS TABLE("BindCardId" bigint, "AccountId" bigint, "CardOwnerId" bigint, "CardHolderId" bigint, "CardHolderContactId" bigint, "IdentifierCard" character varying, "UsageType" character varying, "Attempts" integer, "Status" integer, "OperationId" bigint, "CreationDate" timestamp without time zone, "DeletionDate" timestamp without time zone, "UpdateDate" timestamp without time zone, "CreationUserId" bigint, "UpdateUserId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
SELECT "BindCardId",
        "AccountId",        
		"CardOwnerId",
		"CardHolderId",
		"CardHolderContactId",
		"IdentifierCard",
		"UsageType",
		"Attempts",
		"Status",
		"OperationId",
        "CreationDate",
        "UpdateDate",
        "DeletionDate",
        "CreationUserId",
        "UpdateUserId"

FROM public."BindCard"
WHERE "IdentifierCard" = "paramIdentifier" AND "DeletionDate" is NULL
$BODY$;

ALTER FUNCTION public.getbindcardbyidentifier(character varying)
    OWNER TO "OSB";