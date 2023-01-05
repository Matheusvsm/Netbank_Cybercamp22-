DROP FUNCTION public.insertaccount(bigint, bigint, character varying, bigint, character varying, character varying, bigint);

CREATE OR REPLACE FUNCTION public.insertaccount(
	"paramCompanyId" bigint,	
	"paramName" character varying,	
	"paramType" bigint,
	"paramTaxId" character varying,
	"paramAccountKey" character varying,
	"paramUserId" bigint
	)
    RETURNS TABLE ("AccountId" bigint)
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
INSERT INTO public."Account"
                    (
	                 "CompanyId",					 
					 "Name",
				     "Type",
					 "TaxId",
					 "AccountKey",
					 "CreationDate",
					 "UpdateDate",
					 "CreationUserId",
					 "UpdateUserId"
					 )
				VALUES (
					"paramCompanyId",					
					"paramName",
					"paramType",
					"paramTaxId",
					"paramAccountKey",
					now(),
					now(),
					"paramUserId",
					"paramUserId"
					) RETURNING "AccountId"
$BODY$;

ALTER FUNCTION public.insertaccount(bigint, character varying, bigint, character varying, character varying, bigint)
    OWNER TO "OSB";
