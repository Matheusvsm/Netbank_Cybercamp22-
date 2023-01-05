CREATE OR REPLACE FUNCTION public.deleteuser(
	"paramUserId" bigint)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
Update public."User" 
         set "DeletionDate" = now(),
             "UpdateDate" = now()
		 WHERE 
		 	 "DeletionDate" IS NULL AND
		     "UserId" = "paramUserId"
$BODY$;

ALTER FUNCTION public.deleteuser(bigint)
    OWNER TO "OSB";
