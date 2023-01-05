CREATE OR REPLACE FUNCTION public.getcardholdercontactbyid(
	"paramCardHolderContactId" bigint)
    RETURNS TABLE("CardHolderContactId" bigint, "Phone" character varying, "Mail" character varying, "CreationDate" timestamp without time zone, "DeletionDate" timestamp without time zone, "UpdateDate" timestamp without time zone, "CreationUserId" bigint, "UpdateUserId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
SELECT (
		"CardHolderContactId",
		"Phone",
		"Mail",
		"CreationDate",
		"DeletionDate",
		"UpdateDate",
		"CreationUserId",
		"UpdateUserId"
		)
	FROM public."CardHolderContact"
	WHERE "CardHolderContactId" = "paramCardHolderContactId" AND "DeletionDate" is NULL
$BODY$;

ALTER FUNCTION public.getcardholdercontactbyid(bigint)
    OWNER TO "OSB";