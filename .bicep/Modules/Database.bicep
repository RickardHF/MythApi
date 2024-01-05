
@secure()
param postgresDBUsername string
@secure()
param postgresDBPassword string

param keyVaultId string

param postgresDBLocation string = resourceGroup().location


resource postgresDB 'Microsoft.DBforPostgreSQL/flexibleServers@2023-03-01-preview' = {
  name: 'goddbthisisatest'
  location: postgresDBLocation
  sku: {
    name: 'Standard_B1ms'
    tier: 'Burstable'
  }
  properties: {
    version: '15'
    createMode: 'Default'
    administratorLogin: postgresDBUsername
    administratorLoginPassword: postgresDBPassword
  }
}

output postgresDBID string = postgresDB.id
output connectionString string = postgresDB.properties.fullyQualifiedDomainName

module setAdminUserName 'CreateSecrets.bicep' = {
  name: 'setAdminUsername'
  dependsOn: [
    postgresDB
  ]
  params: {
    keyVaultId: keyVaultId
    secretName: 'databaseUsername' 
    secretValue: postgresDBUsername
  }
}

module setAdminPassword 'CreateSecrets.bicep' = {
  name: 'setAdminPassword'
  dependsOn: [
    postgresDB
  ]
  params: {
    keyVaultId: keyVaultId
    secretName: 'databasePassword' 
    secretValue: postgresDBPassword
  }
}


module setConnectionString 'CreateSecrets.bicep' = {
  name: 'setConnectionString'
  dependsOn: [
    postgresDB
  ]
  params: {
    keyVaultId: keyVaultId
    secretName: 'databaseUsername' 
    secretValue: postgresDBUsername
  }
}
