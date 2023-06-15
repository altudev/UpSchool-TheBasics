
export type ApiResponse<T> = {
    message?: string;
    data?: T;
    errors?: string[];
};

export type PaginatedList<T> = {
    items: T[];
    pageNumber: number;
    totalPages: number;
    totalCount: number;
    hasPreviousPage: boolean;
    hasNextPage: boolean;
};