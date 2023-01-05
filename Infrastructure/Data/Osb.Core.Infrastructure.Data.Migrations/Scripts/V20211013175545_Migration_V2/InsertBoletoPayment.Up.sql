CREATE OR REPLACE FUNCTION public.insertboletopayment(
	"paramAccountId" bigint,
	"paramName" character varying,
	"paramTaxId" character varying,
	"paramReceiverName" character varying,
	"paramReceiverTaxId" character varying,
	"paramPayerName" character varying,
	"paramPayerTaxId" character varying,
	"paramOperationId" bigint,
	"paramStatus" integer,
	"paramBarcode" character varying,
	"paramPaymentValue" numeric,
	"paramPaymentDate" timestamp without time zone,
	"paramDueDate" timestamp without time zone,
	"paramDiscountValue" numeric,
	"paramDescription" character varying,
	"paramIdentifier" character varying,
    "paramUserId" bigint
    )
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
INSERT INTO public."BoletoPayment"
                    (
                     "AccountId",
                     "Name",                     
                     "TaxId",
                     "ReceiverName",
                     "ReceiverTaxId",
                     "PayerName",
                     "PayerTaxId",
                     "OperationId", 
                     "Status",
                     "Barcode",
                     "PaymentValue", 
                     "PaymentDate", 
                     "DueDate", 
                     "DiscountValue",
                     "Description",
                     "Identifier", 
                     "CreationDate",
                     "UpdateDate",
                     "CreationUserId",
                     "UpdateUserId")
    VALUES (
            "paramAccountId",
            "paramName",
            "paramTaxId", 
            "paramReceiverName",
            "paramReceiverTaxId",
            "paramPayerName",
            "paramPayerTaxId",
            "paramOperationId",
            "paramStatus",
            "paramBarcode",
            "paramPaymentValue",
            "paramPaymentDate",
            "paramDueDate",
            "paramDiscountValue",
            "paramDescription",
            "paramIdentifier",
            NOW(),
            NOW(),
            "paramUserId",
            "paramUserId"
            )
$BODY$;

ALTER FUNCTION public.insertboletopayment(bigint, character varying, character varying, character varying, character varying, character varying, character varying, bigint, integer, character varying, numeric, timestamp without time zone, timestamp without time zone, numeric, character varying, character varying, bigint)
    OWNER TO "OSB";
