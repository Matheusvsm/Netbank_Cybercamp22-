DROP FUNCTION public.insertauthorizationtoken(bigint, character varying, character varying, character varying, integer, timestamp without time zone);

CREATE FUNCTION public.insertauthorizationtoken(
	"paramUserId" bigint,
	"paramAccountId" bigint,
	"paramTaxId" character varying,
	"paramCode" character varying,
	"paramSalt" character varying,
	"paramStatus" integer,
	"paramExpirationDate" timestamp without time zone)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
INSERT INTO public."AuthorizationToken"
	(
	"UserId",
	"AccountId",
	"TaxId",
	"Code",
	"Salt",
	"ExpirationDate",
	"Status",
	"CreationDate",
	"UpdateDate",
	"CreationUserId",
	"UpdateUserId"
	)
VALUES (
	"paramUserId",
    "paramAccountId",
	"paramTaxId",
	"paramCode",
	"paramSalt",
	"paramExpirationDate",
	"paramStatus",
	NOW(),
    NOW(),
	"paramUserId",
	"paramUserId"
	)
$BODY$;

ALTER FUNCTION public.insertauthorizationtoken(bigint, bigint, character varying, character varying, character varying, integer, timestamp without time zone)
    OWNER TO "OSB";