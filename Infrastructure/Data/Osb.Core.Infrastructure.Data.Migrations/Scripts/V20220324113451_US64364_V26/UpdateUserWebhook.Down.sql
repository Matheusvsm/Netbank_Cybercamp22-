CREATE OR REPLACE FUNCTION public.updateuserwebhook(
	"paramUserWebhookId" bigint,
	"paramStatus" integer)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
UPDATE public."UserWebhook"
    
    SET 
        "Status" = "paramStatus",
		"UpdateDate" = now()
    WHERE
        "UserWebhookId" = "paramUserWebhookId" AND
        "DeletionDate" IS NULL
$BODY$;

ALTER FUNCTION public.updateuserwebhook(bigint, integer)
    OWNER TO "OSB";