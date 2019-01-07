import React from 'react';
import { List, Datagrid, TextField,ReferenceField } from 'react-admin';

export const BalanceList = (props) => (
    <List title="Balance" {...props}>
        <Datagrid rowClick="edit">
            <TextField source="productId" />
            <ReferenceField label="Product" source="productId" reference="product">
                <TextField source="name" />
            </ReferenceField>
            <TextField source="stockQuantity" />
            <TextField source="totalQuantity" />
            <TextField source="purchaseAmount" />
            <TextField source="sellingAmount" />
        </Datagrid>
    </List>
);


