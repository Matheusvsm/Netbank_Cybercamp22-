CREATE OR REPLACE FUNCTION public.getuserwebhookbystatus(
	"paramStatus" integer
    )
    RETURNS TABLE("UserWebhookId" bigint,
                  "CompanyId" bigint,
                  "TaxId" character varying,
                  "Name" character varying,
                  "Mail" character varying,
                  "PhoneNumber" character varying,
                  "AccountName" character varying,
                  "AccountTaxId" character varying,
                  "EventType" bigint,
                  "UserTaxId" character varying,
                  "AccountKey" character varying,
                  "Password" character varying,
                  "Salt" character varying,
                  "Status" integer,
                  "CreationDate" timestamp without time zone,
                  "UpdateDate" timestamp without time zone,
                  "DeletionDate" timestamp without time zone,
                  "CreationUserId" bigint,
                  "UpdateUserId" bigint)
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000
AS $BODY$
SELECT  "UserWebhookId",
        "CompanyId",
        "TaxId",
        "Name",
        "Mail",
        "PhoneNumber",
        "AccountName",
        "AccountTaxId",
        "EventType",
        "UserTaxId",
        "AccountKey",
        "Password",
        "Salt",
        "Status",
        "CreationDate",
        "UpdateDate",
        "DeletionDate",
        "CreationUserId",
        "UpdateUserId"

FROM public."UserWebhook"
WHERE "Status" = "paramStatus"
    AND "DeletionDate" IS NULL

$BODY$;
ALTER FUNCTION public.getuserwebhookbystatus(integer)
    OWNER TO "OSB";