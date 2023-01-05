CREATE OR REPLACE FUNCTION public.insertcompanyauthentication(
	"paramCompanyAuthenticationId" bigint,
	"paramCompanyId" bigint,
	"paramUrl" character varying,
	"paramSalt" character varying,
	"paramUserName" character varying,
	"paramPassword" character varying)
    RETURNS bigint
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
INSERT INTO public."CompanyAuthentication"(
	"CompanyAuthenticationId",
	"CompanyId",
	"Url",
	"Salt",
	"UserName",
	"Password",
	"CreationDate",
	"UpdateDate",
	"CreationUserId",
	"UpdateUserId"
)
VALUES (
	"paramCompanyAuthenticationId",
	"paramCompanyId",
	"paramUrl",
	"paramSalt",
	"paramUserName",
	"paramPassword",
	now(),
	now(),
	0,
	0
)
RETURNING "CompanyAuthenticationId";
$BODY$;

ALTER FUNCTION public.insertcompanyauthentication(bigint, bigint, character varying, character varying, character varying, character varying)
    OWNER TO "OSB";
