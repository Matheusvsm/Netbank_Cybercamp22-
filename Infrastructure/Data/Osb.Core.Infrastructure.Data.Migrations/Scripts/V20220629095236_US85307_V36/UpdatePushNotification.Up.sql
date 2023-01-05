CREATE OR REPLACE FUNCTION public.updatepushnotification(
    "paramOperationId" bigint,
    "paramTitle" character varying,
    "paramBody" character varying,
    "paramStatus" integer,
    "paramSendDate" timestamp without time zone,
    "paramAttempts" integer,
    "paramUserId" bigint
)
    RETURNS VOID
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
UPDATE public."PushNotification"
    SET
        "Title" = "paramTitle",
        "Body" =  "paramBody",
        "Status" = "paramStatus",
        "SendDate" =  "paramSendDate",
        "Attempts" = "paramAttempts",
        "UpdateDate" = now(),
        "UpdateUserId" = "paramUserId"
    WHERE
        "OperationId" = "paramOperationId"
$BODY$;

ALTER FUNCTION public.updatepushnotification(bigint, character varying, character varying, integer, timestamp without time zone, integer, bigint)
    OWNER TO "OSB";