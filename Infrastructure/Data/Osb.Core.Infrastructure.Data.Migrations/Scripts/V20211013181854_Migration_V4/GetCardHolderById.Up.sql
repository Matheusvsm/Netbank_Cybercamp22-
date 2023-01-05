CREATE OR REPLACE FUNCTION public.getcardholderbyid(
	"paramCardHolderId" bigint)
    RETURNS TABLE("CardHolderId" bigint, "HolderTaxId" character varying, "Nationality" character varying, "MotherName" character varying, "Gender" integer, "FullName" character varying, "BirthDate" character varying, "MaritalStatus" integer, "CreationDate" timestamp without time zone, "DeletionDate" timestamp without time zone, "UpdateDate" timestamp without time zone, "CreationUserId" bigint, "UpdateUserId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
SELECT (
		"CardHolderId",
		"HolderTaxId",
		"Nationality",
		"MotherName",
		"Gender",
		"FullName",
		"BirthDate",
		"MaritalStatus",
		"CreationDate",
		"DeletionDate",
		"UpdateDate",
		"CreationUserId",
		"UpdateUserId"
		)
	FROM public."CardHolder"
	WHERE "CardHolderId" = "paramCardHolderId" AND "DeletionDate" is NULL
$BODY$;

ALTER FUNCTION public.getcardholderbyid(bigint)
    OWNER TO "OSB";