CREATE OR REPLACE FUNCTION public.getaccountbyaccountkey(
	"paramAccountKey" character varying)
    RETURNS TABLE("AccountId" bigint, "CompanyId" bigint, "Name" character varying, "Type" bigint, "Status" bigint, "CreationDate" timestamp without time zone, "UpdateDate" timestamp without time zone, "DeletionDate" timestamp without time zone, "CreationUserId" bigint, "UpdateUserId" bigint, "TaxId" character varying, "AccountKey" character varying) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
SELECT  ACC."AccountId",
        ACC."CompanyId",
        ACC."Name",
        ACC."Type",
        ACC."Status",
        ACC."CreationDate",
        ACC."UpdateDate",
        ACC."DeletionDate",
        ACC."CreationUserId",
        ACC."UpdateUserId",
        ACC."TaxId",
		ACC."AccountKey"
    FROM
        public."Account" AS ACC
    WHERE
        (ACC."AccountKey" = "paramAccountKey")
        AND ACC."DeletionDate" IS NULL;
$BODY$;

ALTER FUNCTION public.getaccountbyaccountkey(character varying)
    OWNER TO "OSB";
