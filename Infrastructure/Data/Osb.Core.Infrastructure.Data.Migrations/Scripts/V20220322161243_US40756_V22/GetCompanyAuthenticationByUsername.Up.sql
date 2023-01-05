CREATE OR REPLACE FUNCTION public.getcompanyauthenticationbyusername(
	"paramUserName" character varying)
    RETURNS TABLE("CompanyAuthenticationId" bigint, "CompanyId" bigint, "Url" character varying, "UserName" character varying, "Password" character varying, "Salt" character varying, "CreationDate" timestamp without time zone, "UpdateDate" timestamp without time zone, "DeletionDate" timestamp without time zone, "CreationUserId" bigint, "UpdateUserId" bigint) 
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
SELECT CA."CompanyAuthenticationId",
	   CA."CompanyId",
	   CA."Url",
	   CA."UserName",
	   CA."Password",
	   CA."Salt",
	   CA."CreationDate",
	   CA."UpdateDate",
	   CA."DeletionDate",
	   CA."CreationUserId",
	   CA."UpdateUserId"
	FROM public."CompanyAuthentication" AS CA
		INNER JOIN "Company" AS CO ON CO."CompanyId" = CA."CompanyId"
	Where
		CA."UserName" = "paramUserName"
	AND 
		CA."DeletionDate" IS NULL;
$BODY$;

ALTER FUNCTION public.getcompanyauthenticationbyusername(character varying)
    OWNER TO "OSB";