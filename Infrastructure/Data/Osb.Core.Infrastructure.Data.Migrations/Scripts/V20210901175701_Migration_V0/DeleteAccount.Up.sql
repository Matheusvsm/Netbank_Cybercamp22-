CREATE OR REPLACE FUNCTION public.deleteaccount(
	"paramAccountId" bigint)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
update public."Account" 
         set "DeletionDate" = now(),
              "UpdateDate" = now()
		 WHERE 
		 	 "DeletionDate" IS NULL AND
		     "AccountId" = "paramAccountId"
$BODY$;

ALTER FUNCTION public.deleteaccount(bigint)
    OWNER TO "OSB";
