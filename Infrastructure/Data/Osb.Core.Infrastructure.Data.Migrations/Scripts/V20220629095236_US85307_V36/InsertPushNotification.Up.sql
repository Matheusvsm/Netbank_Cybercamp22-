CREATE OR REPLACE FUNCTION public.insertpushnotification(
    "paramOperationId" bigint,
    "paramUserId" bigint,
    "paramCompanyId" bigint,
    "paramTitle" character varying,
    "paramBody" character varying,
    "paramStatus" integer,
    "paramSendDate" timestamp without time zone
)
    RETURNS VOID
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE 
AS $BODY$
INSERT INTO public."PushNotification"
    (
        "OperationId",
        "UserId",
        "CompanyId",
        "Title",
        "Body",
        "Status",
        "SendDate",
        "CreationDate",
        "UpdateDate",
        "CreationUserId",
        "UpdateUserId"
    )
    VALUES 
    (
        "paramOperationId",
        "paramUserId",
        "paramCompanyId",
        "paramTitle",
        "paramBody",
        "paramStatus",
        "paramSendDate",
        now(),
        now(),
        "paramUserId",
        "paramUserId"
    )
$BODY$;

ALTER FUNCTION public.insertpushnotification(bigint, bigint, bigint, character varying, character varying, integer, timestamp without time zone)   
    OWNER TO "OSB";