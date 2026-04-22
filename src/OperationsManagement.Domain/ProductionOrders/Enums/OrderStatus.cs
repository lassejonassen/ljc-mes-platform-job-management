namespace OperationsManagement.Domain.ProductionOrders.Enums;

public enum OrderStatus
{
    Draft,      // Th eorder is created (manually or via ERP) but lacks a recipe snapshot or equipment assignment.
    Released,   // The "Master Recipe" has been snapshotted. The order is now visible to the shop floor and ready to be started.
    InProgess,  // At least one child job has started. The order is now consuming time and materials.
    Completed,  // All child jobs are finished. Total yield and scrap are calculated. Final data is ready for ERP "Backflush".
    Aborted,    // The eorder was cancelled mid-production (e.g., due to a major quality issue or machine failure).
    Closed      // The administrative final state. No more data can be changed; the order is archived.
}
