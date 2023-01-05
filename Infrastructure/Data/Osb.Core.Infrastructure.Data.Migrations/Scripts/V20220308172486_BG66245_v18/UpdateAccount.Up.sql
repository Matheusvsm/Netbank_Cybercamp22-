DROP FUNCTION public.updateaccount(bigint, bigint, character varying, bigint, bigint, bigint, character varying, character varying, bigint);

CREATE OR REPLACE FUNCTION public.updateaccount(
	"paramAccountId" bigint,
	"paramCompanyId" bigint,
	"paramName" character varying,
	"paramStatus" bigint,
	"paramType" bigint,	
	"paramAccountKey" character varying,
	"paramTaxId" character varying,
	"paramUserId" bigint
	)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
Update public."Account"
		SET                
	       "CompanyId" = "paramCompanyId",			
		   "Name" = "paramName",
		   "Status" = "paramStatus",
		   "Type" = "paramType",		   
		   "AccountKey" = "paramAccountKey",
		   "TaxId" =  "paramTaxId",
		   "UpdateDate" = now(),
		   "UpdateUserId" = "paramUserId"
		 WHERE 
			"DeletionDate" IS NULL AND
			"AccountId" = "paramAccountId"
$BODY$;

ALTER FUNCTION public.updateaccount(bigint, bigint, character varying, bigint, bigint, character varying, character varying, bigint)
    OWNER TO "OSB";
