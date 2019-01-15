import React from 'react';
import { List, Datagrid, TextField,ReferenceField, Filter,ReferenceInput,SelectInput } from 'react-admin';

export const BalanceList = (props) => (
    <List title="Balance" {...props} filters={<BalanceFilter />}>
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

export const BalanceFilter = (props) => (
    <Filter {...props}>
        <ReferenceInput label="Select Company" source="companyId" reference="company" alwaysOn >
             <SelectInput optionText="name" />
        </ReferenceInput>  
    </Filter>
);


