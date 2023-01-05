CREATE FUNCTION public.deleteuseraccountprofile(
	"paramUserAccountId" bigint,
	"paramProfileId" bigint)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
UPDATE
       "UserAccountProfile"
       SET		
		"DeletionDate" = NOW()

WHERE
		"ProfileId" = "paramProfileId" AND
		"UserAccountId" = "paramUserAccountId"
$BODY$;
ALTER FUNCTION public.deleteuseraccountprofile(bigint, bigint)
    OWNER TO "OSB";