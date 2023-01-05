CREATE OR REPLACE FUNCTION public.insertcompany(
	"paramCompanyId" bigint,
	"paramName" character varying)
    RETURNS bigint
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
INSERT INTO public."Company"(
	"CompanyId",
	"Name", 
	"CreationDate", 
	"UpdateDate",
	"CreationUserId", 
	"UpdateUserId"
)
VALUES (
	"paramCompanyId", 
	"paramName", 
	now(),
	now(), 
	0, 
	0
) 
RETURNING "CompanyId";
$BODY$;

ALTER FUNCTION public.insertcompany(bigint, character varying)
    OWNER TO "OSB";
