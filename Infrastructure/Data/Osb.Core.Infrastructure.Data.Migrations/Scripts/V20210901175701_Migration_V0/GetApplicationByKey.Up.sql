CREATE OR REPLACE FUNCTION public.getapplicationbykey(
	"paramKey" text)
    RETURNS TABLE("ApplicationId" bigint, "CompanyId" bigint, "Name" character varying, "CreationDate" timestamp without time zone, "DeletionDate" timestamp without time zone, "UpdateDate" timestamp without time zone, "CreationUserId" bigint, "UpdateUserId" bigint, "Key" character varying, "Secret" character varying, "Salt" character varying) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
SELECT
        "ApplicationId",
		"CompanyId",
        "Name",
        "CreationDate",
        "DeletionDate",
        "UpdateDate",
        "CreationUserId",
        "UpdateUserId",
        "Key",
        "Secret",
        "Salt"
    FROM
        public."Application"
    Where
        "Key" = "paramKey"
    AND
        "DeletionDate" IS NULL;
$BODY$;

ALTER FUNCTION public.getapplicationbykey(text)
    OWNER TO "OSB";