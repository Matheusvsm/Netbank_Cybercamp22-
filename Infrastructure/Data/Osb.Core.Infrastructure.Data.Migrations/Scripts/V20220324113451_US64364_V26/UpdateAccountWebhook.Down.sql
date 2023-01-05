CREATE OR REPLACE FUNCTION public.updateaccountwebhook(
	"paramAccountWebhookId" bigint,
	"paramStatus" integer)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
UPDATE public."AccountWebhook"
    
    SET 
        "Status" = "paramStatus",
		"UpdateDate" = now()
    WHERE
        "AccountWebhookId" = "paramAccountWebhookId" AND
        "DeletionDate" IS NULL
$BODY$;

ALTER FUNCTION public.updateaccountwebhook(bigint, integer)
    OWNER TO "OSB";