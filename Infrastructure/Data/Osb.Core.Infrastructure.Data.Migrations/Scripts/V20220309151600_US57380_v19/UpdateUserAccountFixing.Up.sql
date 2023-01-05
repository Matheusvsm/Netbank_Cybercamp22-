CREATE FUNCTION public.updateuseraccountfixing(
	"paramAccountId" bigint,
	"paramUserId" bigint,
    "paramIsFixedAccount" boolean
	)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
Update public."UserAccount"
		SET                
	       "UpdateDate" = now(),
		   "IsFixedAccount" = "paramIsFixedAccount"
		 WHERE 
			"DeletionDate" IS NULL 
            AND
			"AccountId" = "paramAccountId"
            AND
            "UserId" = "paramUserId"
$BODY$;

ALTER FUNCTION public.updateuseraccountfixing(bigint, bigint, boolean)
    OWNER TO "OSB";
