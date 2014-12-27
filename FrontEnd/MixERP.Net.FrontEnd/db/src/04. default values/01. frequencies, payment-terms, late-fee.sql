INSERT INTO core.frequencies
SELECT 2, 'EOM', 'End of Month'                 UNION ALL
SELECT 3, 'EOQ', 'End of Quarter'               UNION ALL
SELECT 4, 'EOH', 'End of Half'                  UNION ALL
SELECT 5, 'EOY', 'End of Year';

INSERT INTO core.late_fee(late_fee_code, late_fee_name, is_flat_amount, rate)
SELECT '9%', '9% Fine', false, 9.00; 

INSERT INTO core.payment_terms(payment_term_code, payment_term_name, due_on_date, due_days, due_frequency_id, grace_peiod, late_fee_id, late_fee_posting_frequency_id)
SELECT '07-D',  'Due in next 7 days',                   false,  7,  NULL::integer,  1,  1, 2    UNION ALL
SELECT '15-D',  'Due in next 15 days',                  false,  15, NULL::integer,  2,  1, 2    UNION ALL
SELECT '30-D',  'Due in next 30 days',                  false,  30, NULL::integer,  4,  1, 2    UNION ALL
SELECT 'D-EOM', 'Due in the next month end',            false,  0,  2,              4,  1, 2    UNION ALL
SELECT 'D-EOQ', 'Due in the next quarter end',          false,  0,  3,              4,  1, 2    UNION ALL
SELECT 'D-EOH', 'Due in the next fiscal half end',      false,  0,  4,              4,  1, 2    UNION ALL
SELECT 'D-EOY', 'Due in the next fiscal year end',      false,  0,  5,              4,  1, 2;
