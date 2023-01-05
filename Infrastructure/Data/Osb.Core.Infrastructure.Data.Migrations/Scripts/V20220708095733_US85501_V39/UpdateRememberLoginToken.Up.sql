CREATE OR REPLACE FUNCTION public.updaterememberlogintoken(
	"paramUserId" bigint,
	"paramCompanyId" bigint,
    "paramHashTokenAccess" character varying,
    "paramTokenAccess" character varying)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
UPDATE public."RememberLoginToken"
    SET
        "HashTokenAccess" = "paramHashTokenAccess",
        "TokenAccess" = "paramTokenAccess",
        "UpdateDate" = Now()
    WHERE
        "UserId" = "paramUserId" AND
        "CompanyId" = "paramCompanyId"
$BODY$;

ALTER FUNCTION public.updaterememberlogintoken(bigint, bigint, character varying, character varying)
    OWNER TO "OSB";