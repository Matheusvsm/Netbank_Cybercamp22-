CREATE OR REPLACE FUNCTION public.getlimitedpersonbylimitedaccountid(
	"paramLimitedAccountId" bigint)
    RETURNS TABLE("LimitedPersonId" bigint, "LimitedAccountId" bigint, "Name" character varying, "TaxNumber" character varying, "Mail" character varying, "Phone" character varying, "PersonRoleType" integer, "BirthDate" timestamp without time zone, "CreationDate" timestamp without time zone, "UpdateDate" timestamp without time zone, "DeletionDate" timestamp without time zone, "CreationUserId" bigint, "UpdateUserId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
SELECT "LimitedPersonId",
    "LimitedAccountId",
    "Name",
    "TaxNumber",
    "Mail",
    "Phone",
    "PersonRoleType",
    "BirthDate",
    "CreationDate",
    "UpdateDate",
    "DeletionDate",
    "CreationUserId",
    "UpdateUserId"
FROM public."LimitedPerson"
WHERE "LimitedAccountId" = "paramLimitedAccountId" AND
		"DeletionDate" IS NULL
$BODY$;

ALTER FUNCTION public.getlimitedpersonbylimitedaccountid(bigint)
    OWNER TO "OSB";