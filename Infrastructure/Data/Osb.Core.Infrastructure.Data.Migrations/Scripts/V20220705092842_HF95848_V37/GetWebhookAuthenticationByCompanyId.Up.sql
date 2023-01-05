CREATE OR REPLACE FUNCTION public.getwebhookauthenticationbycompanyid(
	"paramCompanyId" bigint
)
RETURNS TABLE(
	"WebhookAuthenticationId" bigint, 
	"CompanyId" bigint, 
	"Username" character varying,
	"Password" character varying,
	"Salt" character varying,
	"CreationDate" timestamp without time zone, 
	"UpdateDate" timestamp without time zone, 
	"DeletionDate" timestamp without time zone, 
	"CreationUserId" bigint, 
	"UpdateUserId" bigint
) 
LANGUAGE 'sql'
COST 100
VOLATILE PARALLEL UNSAFE
ROWS 1000

AS $BODY$
SELECT
	"WebhookAuthenticationId",
	"CompanyId",
	"Username",
	"Password",
	"Salt",
	"CreationDate",
	"UpdateDate",
	"DeletionDate",
	"CreationUserId", 
	"UpdateUserId"
FROM 
	public."WebhookAuthentication"
WHERE
	"CompanyId" = "paramCompanyId" AND
	"DeletionDate" IS NULL;
$BODY$;

ALTER FUNCTION public.getwebhookauthenticationbycompanyid(bigint)
    OWNER TO "OSB";