import { IProduct } from "./product";

export interface IPaginiation {
    pageIndex: number;
    pageSize: number;
    count: number;
    data: IProduct[];
}

export class Pagination implements IPaginiation {
    pageIndex: number;
    pageSize: number
    count: number;
    data: IProduct[] = [];
}

