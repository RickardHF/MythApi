
@secure()
param postgresDBUsername string
@secure()
param postgresDBPassword string

param postgresDBLocation string = resourceGroup().location


resource postgresDB 'Microsoft.DBforPostgreSQL/servers@2017-12-01' = {
  name: 'goddb-${uniqueString(resourceGroup().id)})'
  location: postgresDBLocation
  sku: {
    name: 'Standard__B1ms'
    tier: 'Burstable'
    capacity: 2
    family: 'Gen5'
  }
  properties: {
    version: '16'
    createMode: 'Default'
    administratorLogin: postgresDBUsername
    administratorLoginPassword: postgresDBPassword
  }
}

output postgresDBID string = postgresDB.id
output connectionString string = postgresDB.properties.fullyQualifiedDomainName
